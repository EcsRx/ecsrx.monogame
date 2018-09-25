using EcsRx.Attributes;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Extensions;
using EcsRx.MonoGame.RogueLike2d.Components;
using EcsRx.MonoGame.RogueLike2d.Groups;
using EcsRx.MonoGame.Wrappers;
using EcsRx.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.RogueLike2d.Systems
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

            var viewComponent = entity.GetComponent<ViewComponent2D>();
            viewComponent.GetTransform().Position = new Vector2(100, 100);

            var movableComponent = entity.GetComponent<MoveableComponent>();
            movableComponent.MovementSpeed = 100.0f;
        }
    }
}