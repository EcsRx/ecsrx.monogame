using EcsRx.Blueprints;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.Plugins.Transforms.Components;

namespace EcsRx.MonoGame.Examples.Asteroids.Blueprint
{
    public class ShipBlueprint : IBlueprint
    {
        public void Apply(IEntity entity)
        {
            var handlingComponent = new HandlingComponent()
            {
                MovementSpeed = 100f,
                RotationSpeed = 5.0f
            };
            
            entity.AddComponents(new PlayerComponent(), handlingComponent, new ColliderComponent(), 
                new ShootingComponent(), new MoveableComponent(), new SpriteComponent(), new Transform2DComponent());
        }
    }
}