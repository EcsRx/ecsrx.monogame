using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Systems;
using EcsRx.MonoGame.Wrappers;
using EcsRx.Plugins.Transforms.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SystemsRx.Attributes;
using SystemsRx.Types;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Infrastructure
{
    [Priority(PriorityTypes.SuperLow)]
    public class SpriteDrawingSystem : SpriteBatchSystem
    {
        public override IGroup Group { get; } =  new Group(typeof(SpriteComponent), typeof(Transform2DComponent));

        public SpriteDrawingSystem(IEcsRxSpriteBatch ecsRxSpriteBatch) : base(ecsRxSpriteBatch)
        {}

        public override void Process(IEntity entity)
        {
            var spriteComponent = entity.GetComponent<SpriteComponent>();
            var transformComponent = entity.GetComponent<Transform2DComponent>();
            var transform = transformComponent.Transform;
            
            var origin = new Vector2(spriteComponent.Sprite.Width / 2f, spriteComponent.Sprite.Height / 2f);
            EcsRxSpriteBatch.Draw(spriteComponent.Sprite, transform.Position, null, Color.White, transform.Rotation, origin, transform.Scale, SpriteEffects.None, 0);
        }
    }
}