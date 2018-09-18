using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.RogueLike2d.Components;
using EcsRx.MonoGame.Systems;
using EcsRx.MonoGame.Wrappers;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.RogueLike2d.Systems
{
    public class ShipDrawingSystem : SpriteBatchSystem
    {
        private readonly Texture2D _shipTexture;
        
        public override IGroup Group { get; } = new Group(typeof(MoveableComponent));

        public ShipDrawingSystem(IEcsRxSpriteBatch ecsRxSpriteBatch, IEcsRxContentManager ecsRxContentManager) : base(ecsRxSpriteBatch)
        {
            _shipTexture = ecsRxContentManager.Load<Texture2D>("ship");
        }

        public override void Process(IEntity entity)
        {
            var moveableComponent = entity.GetComponent<MoveableComponent>();
            EcsRxSpriteBatch.Draw(_shipTexture, moveableComponent.Position);
        }
    }
}