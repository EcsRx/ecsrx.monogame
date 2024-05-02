using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.Systems;
using Microsoft.Xna.Framework.Input;
using SystemsRx.Attributes;
using SystemsRx.Types;
using System.Numerics;
using SystemsRx.Scheduling;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Infrastructure;

[Priority(PriorityTypes.SuperHigh)]
public class HandleInputSystem : IBasicEntitySystem
{
    public IGroup Group { get; } = new Group(typeof(MoveableComponent), typeof(ShootingComponent), typeof(PlayerComponent));
        
    public void Process(IEntity entity, ElapsedTime elapsedTime)
    {
        var playerComponent = entity.GetComponent<PlayerComponent>();
        
        var gamepadState = GamePad.GetState(playerComponent.PlayerIndex);
        var keyboardState = Keyboard.GetState();
        var forwardChange = 0f;
        var strafeChange = 0f;
        var rotationChange = 0f;
        var isFiring = false;

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
        
        if (gamepadState.Buttons.X == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Space))
        { isFiring = true; }
            
        var moveableComponent = entity.GetComponent<MoveableComponent>();
        moveableComponent.MovementChange = new Vector2(strafeChange, forwardChange);
        moveableComponent.DirectionChange = rotationChange;

        var shootingComponent = entity.GetComponent<ShootingComponent>();
        shootingComponent.IsFiring = isFiring;
    }
}