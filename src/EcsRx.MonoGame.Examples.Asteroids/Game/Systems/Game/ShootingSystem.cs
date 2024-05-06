using System.Numerics;
using EcsRx.Collections.Database;
using EcsRx.Collections.Entity;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Examples.Asteroids.Blueprint;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.Plugins.Transforms.Components;
using EcsRx.Systems;
using SystemsRx.Plugins.Transforms.Extensions;
using SystemsRx.Scheduling;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Game;

public class ShootingSystem : IBasicEntitySystem
{
    public float FireRateDelay = 0.5f;
    
    public IGroup Group { get; } = new Group(typeof(ShootingComponent), typeof(Transform2DComponent));
    
    public IEntityCollection EntityCollection { get; }

    public ShootingSystem(IEntityDatabase entityDatabase)
    {
        EntityCollection = entityDatabase.GetCollection();
    }

    public void Process(IEntity entity, ElapsedTime elapsedTime)
    {
        var shootingComponent = entity.GetComponent<ShootingComponent>();
        if (shootingComponent.FireTimeLeft > 0)
        { shootingComponent.FireTimeLeft -= (float)elapsedTime.DeltaTime.TotalSeconds; }

        if (shootingComponent.IsFiring && shootingComponent.FireTimeLeft <= 0)
        {
            shootingComponent.FireTimeLeft += FireRateDelay;
            CreateShotFor(entity);
        }
    }

    public void CreateShotFor(IEntity shooterEntity)
    {
        var shooterTransformComponent = shooterEntity.GetComponent<Transform2DComponent>();
        var shooterTransform = shooterTransformComponent.Transform;

        var projectileEntity = EntityCollection.CreateEntity<ProjectileBlueprint>();
        var projectileTransformComponent = projectileEntity.GetComponent<Transform2DComponent>();
        var projectileTransform = projectileTransformComponent.Transform;
        projectileTransform.Position = shooterTransform.Position;
        projectileTransform.Rotation = shooterTransform.Rotation;
        projectileTransform.Position += projectileTransform.Forward() * 64.0f;

        var projectileComponent = projectileEntity.GetComponent<ProjectileComponent>();
        projectileComponent.PlayerEntityId = shooterEntity.Id;
        
        var moveableComponent = projectileEntity.GetComponent<MoveableComponent>();
        moveableComponent.MovementChange = new Vector2(0, 1); // No Strafe, Just Forwards
    }
}