using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Extensions;
using EcsRx.MonoGame.RogueLike2d.Groups;
using EcsRx.MonoGame.Systems;
using EcsRx.MonoGame.Wrappers;

namespace EcsRx.MonoGame.RogueLike2d.Systems
{
    public class ShipDrawingSystem : SpriteBatchSystem
    {
        public override IGroup Group { get; } = new ShipGroup();

        public ShipDrawingSystem(IEcsRxSpriteBatch ecsRxSpriteBatch) : base(ecsRxSpriteBatch)
        {}

        public override void Process(IEntity entity)
        {
            var spriteComponent = entity.GetComponent<SpriteComponent>();
            var viewComponent = entity.GetComponent<ViewComponent2D>();
            EcsRxSpriteBatch.Draw(spriteComponent.Sprite, viewComponent.GetTransform().Position);
        }
    }
}