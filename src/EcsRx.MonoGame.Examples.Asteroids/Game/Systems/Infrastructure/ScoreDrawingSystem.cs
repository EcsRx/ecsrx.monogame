using Comora;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
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
    public class ScoreDrawingSystem : SpriteBatchSystem
    {
        public override IGroup Group { get; } =  new Group(typeof(PlayerComponent));
        public SpriteFont GameFont { get; }
        
        public ScoreDrawingSystem(IEcsRxSpriteBatch ecsRxSpriteBatch, IEcsRxContentManager contentManager) : base(ecsRxSpriteBatch)
        {
            GameFont = contentManager.Load<SpriteFont>("GameFont");
        }

        public override void Process(IEntity entity)
        {
            var playerComponent = entity.GetComponent<PlayerComponent>();

            var playerNumber = playerComponent.PlayerIndex + 1;
            var position = new Vector2(24, playerNumber * 24);
            EcsRxSpriteBatch.DrawString(GameFont, $"Player {playerNumber}: {playerComponent.Score.ToString()}", position, Color.White);
        }
    }
}