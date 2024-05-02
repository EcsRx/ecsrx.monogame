using EcsRx.Components;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Components;

public class HandlingComponent : IComponent
{
    public float MovementSpeed { get; set; }
    public float RotationSpeed { get; set; }
}