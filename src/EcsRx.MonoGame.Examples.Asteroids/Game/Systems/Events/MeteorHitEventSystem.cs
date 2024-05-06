using System;
using EcsRx.Collections.Database;
using EcsRx.Collections.Entity;
using EcsRx.Extensions;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.MonoGame.Examples.Asteroids.Game.Events;
using EcsRx.MonoGame.Examples.Asteroids.Types;
using SystemsRx.Systems.Conventional;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Events;

public class MeteorHitEventSystem : IReactToEventSystem<MeteorCollidedWithProjectileEvent>
{
    public IEntityCollection EntityCollection { get; }

    public MeteorHitEventSystem(IEntityDatabase entityDatabase)
    {
        EntityCollection = entityDatabase.GetCollection();
    }

    public void Process(MeteorCollidedWithProjectileEvent eventData)
    {
        var meteorComponent = eventData.Meteor.GetComponent<MeteorComponent>();

        var projectileComponent = eventData.Projectile.GetComponent<ProjectileComponent>();
        var owningShip = EntityCollection.GetEntity(projectileComponent.PlayerEntityId);
        
        var playerComponent = owningShip.GetComponent<PlayerComponent>();
        playerComponent.Score += CalculateScoreFor(meteorComponent);
        
        EntityCollection.RemoveEntity(eventData.Meteor.Id);
        EntityCollection.RemoveEntity(eventData.Projectile.Id);
    }

    private int CalculateScoreFor(MeteorComponent meteorComponent)
    {
        switch (meteorComponent.Type)
        {
            case MeteorType.Medium: return 200;
            case MeteorType.Small: return 500;
            case MeteorType.Big:
            default: return 100;
        }
    }
}