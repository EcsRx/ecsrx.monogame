using EcsRx.Components;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Components;

public class HasLifetimeComponent : IComponent
{
    public float MaxAliveTime { get; set; }
    public float AliveTime { get; set; }
}