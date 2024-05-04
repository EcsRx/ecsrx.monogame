using EcsRx.Components;
using EcsRx.MonoGame.Examples.Asteroids.Types;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Components;

public class MeteorComponent : IComponent
{
    public MeteorType Type { get; set; } = MeteorType.Big;
}