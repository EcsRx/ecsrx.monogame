using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Extensions;
using EcsRx.MonoGame.RogueLike2d.Game.Components;
using EcsRx.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EcsRx.MonoGame.RogueLike2d.Game.Systems
{
    public class MovementSystem : IBasicSystem
    {
        public IGroup Group { get; } = new Group(typeof(MoveableComponent), typeof(ViewComponent2D));

        private readonly IGameScheduler _gameScheduler;

        public MovementSystem(IGameScheduler gameScheduler)
        {
            _gameScheduler = gameScheduler;
        }

        public void Process(IEntity entity)
        {
            var gamepadState = GamePad.GetState(PlayerIndex.One);
            var keyboardState = Keyboard.GetState();
            var movementChange = new Vector2();

            if (gamepadState.DPad.Up == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
            { movementChange.Y -= 1; }
            else if (gamepadState.DPad.Down == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
            { movementChange.Y += 1;}
            
            if (gamepadState.DPad.Left == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            { movementChange.X -= 1; }
            else if (gamepadState.DPad.Right == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            { movementChange.X += 1; }
            
            if(movementChange == Vector2.Zero) { return; }
            
            var moveableComponent = entity.GetComponent<MoveableComponent>();
            var movementSpeed = moveableComponent.MovementSpeed * (float)_gameScheduler.GameTime.ElapsedGameTime.TotalSeconds;

            var viewComponent = entity.GetComponent<ViewComponent2D>();
            viewComponent.GetTransform().Position += movementChange * movementSpeed;
        }
    }
}