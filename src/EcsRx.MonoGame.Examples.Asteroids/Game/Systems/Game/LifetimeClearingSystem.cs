using System;
using System.Reactive.Linq;
using EcsRx.Collections.Database;
using EcsRx.Collections.Entity;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.Systems;
using SystemsRx.Scheduling;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Game;

public class LifetimeClearingSystem : IBasicEntitySystem
{
    public IGroup Group { get; } = new Group(typeof(HasLifetimeComponent));
    public IEntityCollection EntityCollection { get; }
    public IUpdateScheduler UpdateScheduler { get; }

    public LifetimeClearingSystem(IEntityDatabase entityDatabase, IUpdateScheduler updateScheduler)
    {
        UpdateScheduler = updateScheduler;
        EntityCollection = entityDatabase.GetCollection();
    }

    public void Process(IEntity entity, ElapsedTime elapsedTime)
    {
        var lifetimeComponent = entity.GetComponent<HasLifetimeComponent>();
        lifetimeComponent.AliveTime += (float)elapsedTime.DeltaTime.TotalSeconds;

        if (lifetimeComponent.AliveTime >= lifetimeComponent.MaxAliveTime)
        {
            UpdateScheduler.OnPostUpdate.Take(1).Subscribe(_ => {
                EntityCollection.RemoveEntity(entity.Id);
            });
        }
    }
}