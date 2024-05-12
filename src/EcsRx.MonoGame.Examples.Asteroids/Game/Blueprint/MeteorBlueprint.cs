using EcsRx.Blueprints;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.MonoGame.Examples.Asteroids.Types;
using EcsRx.Plugins.Transforms.Components;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Blueprint;

public class MeteorBlueprint : IBlueprint
{
    public MeteorType MeteorType { get; set; } = MeteorType.Big;
    
    public void Apply(IEntity entity)
    {
        var handlingComponent = new HandlingComponent()
        {
            MovementSpeed = 90f,
            RotationSpeed = 4.0f
        };

        var lifetimeComponent = new HasLifetimeComponent()
        {
            MaxAliveTime = 10.0f
        };

        var meteorComponent = new MeteorComponent()
        {
            Type = MeteorType
        };
        
        entity.AddComponents(handlingComponent, meteorComponent, lifetimeComponent, 
            new MoveableComponent(), new ColliderComponent(), new SpriteComponent(), new Transform2DComponent());
    }
}