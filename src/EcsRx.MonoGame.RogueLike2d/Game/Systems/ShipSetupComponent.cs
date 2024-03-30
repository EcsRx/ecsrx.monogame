using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.RogueLike2d.Game.Components;
using EcsRx.MonoGame.RogueLike2d.Groups;
using EcsRx.MonoGame.Wrappers;
using EcsRx.Plugins.ReactiveSystems.Systems;
using EcsRx.Plugins.Transforms.Components;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = System.Numerics.Vector2;

namespace EcsRx.MonoGame.RogueLike2d.Game.Systems
{
    public class ShipSetupComponent : ISetupSystem
    {
        public IGroup Group { get; } = new ShipGroup();
        
        public IEcsRxContentManager ContentManager { get; }

        public ShipSetupComponent(IEcsRxContentManager contentManager)
        { ContentManager = contentManager; }

        public void Setup(IEntity entity)
        {
            var spriteComponent = entity.GetComponent<SpriteComponent>();
            spriteComponent.Sprite = ContentManager.Load<Texture2D>("ship");

            var viewComponent = entity.GetComponent<Transform2DComponent>();
            viewComponent.Transform.Position = new Vector2(100, 100);

            var movableComponent = entity.GetComponent<MoveableComponent>();
            movableComponent.MovementSpeed = 100.0f;
        }
    }
}