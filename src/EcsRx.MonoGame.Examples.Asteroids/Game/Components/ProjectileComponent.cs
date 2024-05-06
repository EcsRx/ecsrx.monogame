using EcsRx.Components;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Components;

public class ProjectileComponent : IComponent
{
    public int PlayerEntityId { get; set; }
}