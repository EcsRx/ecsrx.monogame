using EcsRx.Components;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Components;

public class ColliderComponent : IComponent
{
    public float Width { get; set; }
    public float Height { get; set; }
}