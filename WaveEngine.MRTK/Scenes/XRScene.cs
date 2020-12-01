﻿// Copyright © Wave Engine S.L. All rights reserved. Use is subject to license terms.

using System;
using System.Collections.Generic;
using WaveEngine.Bullet;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Input.Keyboard;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Components.Primitives;
using WaveEngine.Components.XR;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics3D;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.XR;
using WaveEngine.Mathematics;
using WaveEngine.MRTK.Behaviors;
using WaveEngine.MRTK.Emulation;
using WaveEngine.MRTK.Services.InputSystem;
using Billboard = WaveEngine.MRTK.Behaviors.Billboard;

namespace WaveEngine.MRTK.Scenes
{
    /// <summary>
    /// Base class for scenes using XR.
    /// </summary>
    public abstract class XRScene : Scene
    {
        /// <summary>
        /// Gets cursors material Guid for released state.
        /// </summary>
        protected abstract Guid CursorMatReleased { get; }

        /// <summary>
        /// Gets cursors material Guid for pressed state.
        /// </summary>
        protected abstract Guid CursorMatPressed { get; }

        /// <summary>
        /// Gets holo hands material Guid.
        /// </summary>
        protected abstract Guid HoloHandsMat { get; }

        /// <summary>
        /// Gets spatial mapping material Guid.
        /// </summary>
        protected abstract Guid SpatialMappingMat { get; }

        /// <summary>
        /// Gets holographics effect Guid.
        /// </summary>
        protected abstract Guid HolographicEffect { get; }

        /// <summary>
        /// Gets the texture for the hand rays.
        /// </summary>
        protected abstract Guid HandRayTexture { get; }

        /// <summary>
        /// Gets the Sampler for the hand rays.
        /// </summary>
        protected abstract Guid HandRaySampler { get; }

        /// <inheritdoc/>
        public override void RegisterManagers()
        {
            base.RegisterManagers();

            this.Managers.AddManager(new BulletPhysicManager3D());
            this.Managers.AddManager(new CursorManager());
        }

        /// <inheritdoc/>
        protected override void CreateScene()
        {
            this.Managers.EntityManager.FindFirstComponentOfType<MeshRenderer>(tag: "Skybox").IsEnabled = false;

            var assetsService = Application.Current.Container.Resolve<AssetsService>();

            InitHoloScene(
                this,
                assetsService.Load<Material>(this.CursorMatReleased),
                assetsService.Load<Material>(this.CursorMatPressed),
                this.HoloHandsMat == Guid.Empty ? null : assetsService.Load<Material>(this.HoloHandsMat),
                this.SpatialMappingMat == Guid.Empty ? null : assetsService.Load<Material>(this.SpatialMappingMat),
                this.HolographicEffect,
                assetsService.Load<Texture>(this.HandRayTexture),
                assetsService.Load<SamplerState>(this.HandRaySampler));
        }

        /// <inheritdoc/>
        protected override void Start()
        {
            base.Start();

            // Create GazeProvider
            Camera3D cam = this.Managers.EntityManager.FindFirstComponentOfType<Camera3D>();
            cam.Owner.AddComponent(new GazeProvider());
        }

        private static void CreateXRHandMesh(Scene scene, Material material, XRHandedness handedness)
        {
            Entity handEntity = new Entity()
                .AddComponent(new Transform3D())
                .AddComponent(new MaterialComponent() { Material = material })
                .AddComponent(new XRDeviceMeshComponent()
                {
                    XRModelName = handedness.ToString(),
                })
                .AddComponent(new MeshRenderer())
                .AddComponent(new TrackModelNode()
                {
                    SelectionStrategy = TrackModelNode.SelectionNodeStrategy.RootNode,
                })
                .AddComponent(new HoloHandsUpdater() { Handedness = handedness })
                ;

            scene.Managers.EntityManager.Add(handEntity);
        }

        private static Entity CreateCursor(Scene scene, Material releasedMaterial, Material pressedMaterial, XRHandedness handedness, Texture handRayTexture, SamplerState handRaySampler)
        {
            Entity cursor = new Entity("Cursor_" + handedness)
                .AddComponent(new Transform3D())
                .AddComponent(new MaterialComponent())
                .AddComponent(new PlaneMesh() { TwoSides = true, Normal = Vector3.Forward, Width = 0.01f, Height = 0.01f })
                .AddComponent(new MeshRenderer())
                .AddComponent(new SphereCollider3D())
                .AddComponent(new StaticBody3D() { CollisionCategories = CollisionCategory3D.Cat2, IsSensor = true, MaskBits = CollisionCategory3D.Cat1 })
                .AddComponent(new Cursor() { PressedMaterial = pressedMaterial, ReleasedMaterial = releasedMaterial, UpdateOrder = 0.3f })
                .AddComponent(new ProximityLight())
                ;

            TrackXRJoint trackXRJoint = null;
            var xrPlatform = Application.Current.Container.Resolve<XRPlatform>();
            if (xrPlatform != null)
            {
                trackXRJoint = new TrackXRJoint()
                {
                    Handedness = handedness,
                    SelectionStrategy = TrackXRDevice.SelectionDeviceStrategy.ByHandedness,
                    JointKind = XRHandJointKind.IndexTip,
                    TrackingLostMode = TrackXRDevice.XRTrackingLostMode.KeepLastPose,
                };

                // HoloLens 2
                cursor.AddComponent(trackXRJoint)
                    .AddComponent(new HoloLensControlBehavior())
                    ;
            }
            else
            {
                // Windows
                cursor.AddComponent(new MouseControlBehavior() { key = handedness == XRHandedness.RightHand ? Keys.LeftShift : Keys.Space });
            }

            scene.Managers.EntityManager.Add(cursor);

            LineBezierMesh bezierComp = new LineBezierMesh()
            {
                IsCameraAligned = true,
                LinePoints = new List<BezierPointInfo>()
                        {
                            new BezierPointInfo() { Position = Vector3.Zero, Thickness = 0.003f, Color = Color.White },
                            new BezierPointInfo() { Position = Vector3.Zero, Thickness = 0.003f, Color = Color.White },
                            new BezierPointInfo() { Position = Vector3.One,  Thickness = 0.003f, Color = Color.White },
                        },
                Resolution = 10,
                DiffuseTexture = handRayTexture,
                DiffuseSampler = handRaySampler,
                TextureTiling = new Vector2(10.0f, 1.0f),
            };

            Entity bezier = new Entity()
                .AddComponent(new Transform3D())
                .AddComponent(bezierComp)
                .AddComponent(new LineMeshRenderer3D())
                ;
            scene.Managers.EntityManager.Add(bezier);

            Entity cursorDist = new Entity("CursorDist_" + handedness)
                .AddComponent(new Transform3D())
                .AddComponent(new MaterialComponent())
                .AddComponent(new PlaneMesh() { Normal = Vector3.Forward, Width = 0.01f, Height = 0.01f })
                .AddComponent(new MeshRenderer())
                .AddComponent(new SphereCollider3D())
                .AddComponent(new StaticBody3D() { CollisionCategories = CollisionCategory3D.Cat2, IsSensor = true, MaskBits = CollisionCategory3D.Cat1 })
                .AddComponent(new Cursor() { PressedMaterial = pressedMaterial, ReleasedMaterial = releasedMaterial, UpdateOrder = 0.3f })
                .AddComponent(new CursorRay() { MainCursor = cursor.FindComponent<Cursor>(), Bezier = bezierComp, joint = trackXRJoint, collisionMask = CollisionCategory3D.Cat1 })
                .AddComponent(new Billboard())
                ;
            scene.Managers.EntityManager.Add(cursorDist);

            return cursor;
        }

        /// <summary>
        /// Initializes scene for holololens.
        /// </summary>
        /// <param name="scene">Scene to add components to.</param>
        /// <param name="cursorMatReleased">Material for the cursor when it's released.</param>
        /// <param name="cursorMatPressed">Material for the cursor when it's pressed.</param>
        /// <param name="handMat">Material for the hands.</param>
        /// <param name="spatialMappingMat">Maerial for the spatial mapping.</param>
        /// <param name="holographicsEffectId">Id for holographic effect.</param>
        /// <param name="handRayTexture">Texture for handrays.</param>
        /// <param name="handRaySampler">Sampler for the handrays texture.</param>
        public static void InitHoloScene(Scene scene, Material cursorMatReleased, Material cursorMatPressed, Material handMat, Material spatialMappingMat, Guid holographicsEffectId, Texture handRayTexture, SamplerState handRaySampler)
        {
            var assetsService = Application.Current.Container.Resolve<AssetsService>();

            // Create cursors
            CreateCursor(scene, cursorMatReleased, cursorMatPressed, XRHandedness.LeftHand, handRayTexture, handRaySampler);
            CreateCursor(scene, cursorMatReleased, cursorMatPressed, XRHandedness.RightHand, handRayTexture, handRaySampler);

            // Create hand meshes
            if (handMat != null)
            {
                CreateXRHandMesh(scene, handMat, XRHandedness.LeftHand);
                CreateXRHandMesh(scene, handMat, XRHandedness.RightHand);
            }

            // Create position updater
            scene.Managers.AddManager(new CursorPosShaderUpdater(holographicsEffectId));

            // Create spatial mapping
            SpatialMapping spatialMapping = new SpatialMapping() { GenerateColliders = true, Material = spatialMappingMat };
            spatialMapping.UpdateInterval = new TimeSpan(0, 0, 1);
            scene.Managers.EntityManager.Add(new Entity("SpatialMapping")
                .AddComponent(new Transform3D())
                .AddComponent(spatialMapping));
        }
    }
}
