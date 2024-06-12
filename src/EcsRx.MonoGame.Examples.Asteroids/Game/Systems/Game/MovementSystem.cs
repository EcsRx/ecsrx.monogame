using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.Plugins.Transforms.Components;
using EcsRx.Systems;
using SystemsRx.Attributes;
using SystemsRx.Plugins.Transforms.Extensions;
using SystemsRx.Scheduling;
using SystemsRx.Types;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Game;

[Priority(PriorityTypes.Higher)]
public class MovementSystem : IBasicEntitySystem
{
    public IGroup Group { get; } = new Group(typeof(HandlingComponent), typeof(MoveableComponent), typeof(Transform2DComponent));

    public void Process(IEntity entity, ElapsedTime elapsedTime)
    {
        var handlingComponent = entity.GetComponent<HandlingComponent>();
        var moveableComponent = entity.GetComponent<MoveableComponent>();
        var transformComponent = entity.GetComponent<Transform2DComponent>();

        var movementSpeed = handlingComponent.MovementSpeed * (float)elapsedTime.DeltaTime.TotalSeconds;
        var rotationSpeed = handlingComponent.RotationSpeed * (float)elapsedTime.DeltaTime.TotalSeconds;
            
        var transform = transformComponent.Transform;
        transform.Position += transform.Forward() * moveableComponent.MovementChange.Y * movementSpeed;
        transform.Position += transform.Right() * moveableComponent.MovementChange.X * movementSpeed;
        transform.Rotation += moveableComponent.DirectionChange * rotationSpeed;
    }
}