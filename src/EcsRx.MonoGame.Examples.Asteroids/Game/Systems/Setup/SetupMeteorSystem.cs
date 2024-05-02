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
using Vector2 = System.Numerics.Vector2;
using VectorExtensions = EcsRx.MonoGame.Examples.Asteroids.Extensions.VectorExtensions;

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

            var spawnPosition = GetRandomOffScreenPosition();
            var centerPosition = new Vector2(GraphicsDevice.Viewport.Width/2.0f, GraphicsDevice.Viewport.Height/2.0f);
            var viewComponent = entity.GetComponent<Transform2DComponent>();
            viewComponent.Transform.Position = spawnPosition;
            viewComponent.Transform.GetLookAt(centerPosition);

            var moveableComponent = entity.GetComponent<MoveableComponent>();
            moveableComponent.MovementChange = Vector2.Normalize(-spawnPosition);
        }

        public Vector2 GetRandomOffScreenPosition()
        {
            var bufferAmount = 30;
            var isVerticalSpawn = Random.NextBool();

            if (isVerticalSpawn)
            {
                var randomY = Random.Next(-bufferAmount, GraphicsDevice.Viewport.Height + bufferAmount);
                var leftOrRight = Random.NextBool() ? GraphicsDevice.Viewport.Width + bufferAmount : -bufferAmount;
                return new Vector2(leftOrRight, randomY);
            }
            
            var randomX = Random.Next(-bufferAmount, GraphicsDevice.Viewport.Width + bufferAmount);
            var topOrBottom = Random.NextBool() ? GraphicsDevice.Viewport.Height + bufferAmount : -bufferAmount;
            return new Vector2(randomX, topOrBottom);
        }
    }
}