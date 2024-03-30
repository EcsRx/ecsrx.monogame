using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Extensions;
using EcsRx.MonoGame.RogueLike2d.Groups;
using EcsRx.MonoGame.Systems;
using EcsRx.MonoGame.Wrappers;
using EcsRx.Plugins.Transforms.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.RogueLike2d.Game.Systems
{
    public class ShipDrawingSystem : SpriteBatchSystem
    {
        public override IGroup Group { get; } = new ShipGroup();

        public ShipDrawingSystem(IEcsRxSpriteBatch ecsRxSpriteBatch) : base(ecsRxSpriteBatch)
        {}

        public override void Process(IEntity entity)
        {
            var spriteComponent = entity.GetComponent<SpriteComponent>();
            var transformComponent = entity.GetComponent<Transform2DComponent>();
            var transform = transformComponent.Transform;
            var origin = new Vector2(spriteComponent.Sprite.Width / 2f, spriteComponent.Sprite.Height / 2f);

            //var rotation = transform.RotationAsRadians();
            EcsRxSpriteBatch.Draw(spriteComponent.Sprite, transform.Position, null, Color.White, transform.Rotation, origin, transform.Scale, SpriteEffects.None, 0);
        }
    }
}