using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.MonoGame.Wrappers;
using EcsRx.Plugins.ReactiveSystems.Systems;
using EcsRx.Plugins.Transforms.Components;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Setup
{
    public class SetupProjectileSystem : ISetupSystem
    {
        public IGroup Group { get; } = new Group(typeof(ProjectileComponent), typeof(SpriteComponent), typeof(Transform2DComponent), typeof(ColliderComponent), typeof(MoveableComponent));
        
        public IEcsRxContentManager ContentManager { get; }
        
        public SetupProjectileSystem(IEcsRxContentManager contentManager)
        {
            ContentManager = contentManager;
        }

        public void Setup(IEntity entity)
        {
            var spriteComponent = entity.GetComponent<SpriteComponent>();
            spriteComponent.Sprite = ContentManager.Load<Texture2D>("laser");

            var colliderComponent = entity.GetComponent<ColliderComponent>();
            colliderComponent.Width = spriteComponent.Sprite.Width;
            colliderComponent.Height = spriteComponent.Sprite.Height;
        }
    }
}