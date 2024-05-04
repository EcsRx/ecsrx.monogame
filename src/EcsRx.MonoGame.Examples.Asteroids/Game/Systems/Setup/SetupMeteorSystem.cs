using System;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Examples.Asteroids.Extensions;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.MonoGame.Wrappers;
using EcsRx.Plugins.ReactiveSystems.Systems;
using EcsRx.Plugins.Transforms.Components;
using Microsoft.Xna.Framework.Graphics;
using SystemsRx.Plugins.Transforms.Extensions;
using SystemsRx.Plugins.Transforms.Models;
using Vector2 = System.Numerics.Vector2;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Setup
{
    public class SetupMeteorSystem : ISetupSystem
    {
        public IGroup Group { get; } = new Group(typeof(MeteorComponent), typeof(SpriteComponent), typeof(Transform2DComponent), typeof(ColliderComponent), typeof(MoveableComponent));
        
        public IEcsRxContentManager ContentManager { get; }
        public IEcsRxGraphicsDevice GraphicsDevice { get; }
        public Random Random { get; } = new Random();
        
        public SetupMeteorSystem(IEcsRxContentManager contentManager, IEcsRxGraphicsDevice graphicsDevice)
        {
            ContentManager = contentManager;
            GraphicsDevice = graphicsDevice;
        }

        public void Setup(IEntity entity)
        {
            var spriteComponent = entity.GetComponent<SpriteComponent>();
            spriteComponent.Sprite = ContentManager.Load<Texture2D>("meteor");

            var colliderComponent = entity.GetComponent<ColliderComponent>();
            colliderComponent.Width = spriteComponent.Sprite.Width;
            colliderComponent.Height = spriteComponent.Sprite.Height;

            var spawnPosition = GetRandomSpawnPosition();
            var targetPosition = GetTargetPosition();
            var transformComponent = entity.GetComponent<Transform2DComponent>();
            var viewTransform = transformComponent.Transform;
            
            viewTransform.Position = spawnPosition;
            
            // This may look odd, but in MG apparently 0 rotation should be pointing right not up and its Y negative to move up
            // with this in mind we offset the outputted rotation by 90 degrees (in radians) to make it work correctly
            viewTransform.Rotation = viewTransform.GetLookAt(targetPosition, 1.5708f);
            
            var moveableComponent = entity.GetComponent<MoveableComponent>();
            moveableComponent.MovementChange = new Vector2(0, 1);
        }
        
        public Vector2 GetRandomSpawnPosition()
        {
            var bufferAmount = 64;
            var spawnAreaWidth = GraphicsDevice.Viewport.Width/2 + bufferAmount;
            var spawnAreaHeight = GraphicsDevice.Viewport.Height/2 + bufferAmount;
            
            var isVerticalSpawn = Random.NextBool();

            if (isVerticalSpawn)
            {
                var randomY = Random.Next(-spawnAreaHeight, spawnAreaHeight);
                var leftOrRight = Random.NextBool() ? -spawnAreaWidth : spawnAreaWidth;
                return new Vector2(leftOrRight, randomY);
            }
            
            var randomX = Random.Next(-spawnAreaWidth, spawnAreaWidth);
            var topOrBottom = Random.NextBool() ? -spawnAreaHeight : spawnAreaHeight;
            return new Vector2(randomX, topOrBottom);
        }

        public Vector2 GetTargetPosition()
        {
            var range = 128;
            var varianceX = Random.Next(-range, range);
            var varianceY = Random.Next(-range, range);
            return new Vector2(varianceX, varianceY);
        }
    }
}