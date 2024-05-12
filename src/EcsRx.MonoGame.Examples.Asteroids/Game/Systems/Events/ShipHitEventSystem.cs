using System;
using System.Reactive.Linq;
using EcsRx.Collections.Database;
using EcsRx.Collections.Entity;
using EcsRx.Extensions;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.MonoGame.Examples.Asteroids.Game.Events;
using SystemsRx.Scheduling;
using SystemsRx.Systems.Conventional;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Events;

public class ShipHitEventSystem : IReactToEventSystem<MeteorCollidedWithShipEvent>
{
    public IEntityCollection EntityCollection { get; }
    public IUpdateScheduler UpdateScheduler { get; }
    
    public ShipHitEventSystem(IEntityDatabase entityDatabase, IUpdateScheduler updateScheduler)
    {
        UpdateScheduler = updateScheduler;
        EntityCollection = entityDatabase.GetCollection();
    }

    public void Process(MeteorCollidedWithShipEvent eventData)
    {
        var playerComponent = eventData.Ship.GetComponent<PlayerComponent>();
        playerComponent.Score -= 500;

        if (playerComponent.Score < 0)
        { playerComponent.Score = 0; }
        
        UpdateScheduler.OnPostUpdate.Take(1).Subscribe(_ =>
        {
            EntityCollection.RemoveEntity(eventData.Meteor.Id);
        });
    }
}