using SystemsRx.Scheduling;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.RogueLike2d.Game.Components;
using EcsRx.Plugins.Transforms.Components;
using EcsRx.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SystemsRx.Plugins.Transforms.Extensions;

namespace EcsRx.MonoGame.RogueLike2d.Game.Systems
{
    public class MovementSystem : IBasicEntitySystem
    {
        public IGroup Group { get; } = new Group(typeof(MoveableComponent), typeof(Transform2DComponent));

        private readonly ITimeTracker _timeTracker;

        public MovementSystem(ITimeTracker timeTracker)
        {
            _timeTracker = timeTracker;
        }

        public void Process(IEntity entity)
        {
            var gamepadState = GamePad.GetState(PlayerIndex.One);
            var keyboardState = Keyboard.GetState();
            var forwardChange = 0;
            var strafeChange = 0;
            var rotationChange = 0;

            if (gamepadState.DPad.Up == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.W))
            { forwardChange = 1; }
            else if (gamepadState.DPad.Down == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.S))
            { forwardChange = -1;}
            
            if (gamepadState.DPad.Left == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.A))
            { strafeChange = -1; }
            else if (gamepadState.DPad.Right == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.D))
            { strafeChange = 1; }
            
            if (gamepadState.Triggers.Left != 0 || keyboardState.IsKeyDown(Keys.Q))
            { rotationChange = -1; }
            else if (gamepadState.Triggers.Right != 0 ||keyboardState.IsKeyDown(Keys.E))
            { rotationChange = 1; }
            
            if(forwardChange == 0 && strafeChange == 0 && rotationChange == 0) { return; }
            
            var moveableComponent = entity.GetComponent<MoveableComponent>();
            var movementSpeed = moveableComponent.MovementSpeed * (float)_timeTracker.ElapsedTime.DeltaTime.TotalSeconds;

            var transformComponent = entity.GetComponent<Transform2DComponent>();
            var transform = transformComponent.Transform;
            transform.Position += transform.Forward() * forwardChange * movementSpeed;
            transform.Position += transform.Right() * strafeChange * movementSpeed;
            transform.Rotation += rotationChange * movementSpeed * 0.05f;
        }
    }
}