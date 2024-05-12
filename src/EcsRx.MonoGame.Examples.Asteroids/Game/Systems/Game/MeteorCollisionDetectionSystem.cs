using System;
using System.Linq;
using System.Reactive.Linq;
using EcsRx.Collections;
using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Groups.Observable;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.MonoGame.Examples.Asteroids.Game.Computed;
using EcsRx.MonoGame.Examples.Asteroids.Game.Events;
using EcsRx.Plugins.ReactiveSystems.Systems;
using EcsRx.Plugins.Transforms.Components;
using SystemsRx.Events;
using SystemsRx.Extensions;
using SystemsRx.Scheduling;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Game;

public class MeteorCollisionDetectionSystem : IReactToGroupExSystem
{
    public IGroup Group { get; } = new Group(typeof(MeteorComponent), typeof(ColliderComponent), typeof(Transform2DComponent));
    
    public IUpdateScheduler UpdateScheduler { get; }
    public IEventSystem EventSystem { get; }
    public IObservableGroup ShipObservableGroup { get; }
    public IObservableGroup ProjectileObservableGroup { get; }
    public ComputedRuntimeColliders RuntimeColliders { get; }

    public MeteorCollisionDetectionSystem(IObservableGroupManager observableGroupManager, IEventSystem eventSystem, ComputedRuntimeColliders runtimeColliders, IUpdateScheduler updateScheduler)
    {
        EventSystem = eventSystem;
        RuntimeColliders = runtimeColliders;
        UpdateScheduler = updateScheduler;
        ShipObservableGroup = observableGroupManager.GetObservableGroup(new Group(typeof(PlayerComponent), typeof(ColliderComponent), typeof(Transform2DComponent)));
        ProjectileObservableGroup = observableGroupManager.GetObservableGroup(new Group(typeof(ProjectileComponent), typeof(ColliderComponent), typeof(Transform2DComponent)));
    }
    
    public IObservable<IObservableGroup> ReactToGroup(IObservableGroup observableGroup)
    { return UpdateScheduler.OnUpdate.Select(x => observableGroup); }

    public void Process(IEntity entity)
    {
        var meteorCollisionArea = RuntimeColliders[entity.Id];
        ShipObservableGroup
            .Where(x => meteorCollisionArea.Intersects(RuntimeColliders[x.Id]))
            .ForEachRun(x => EventSystem.Publish(new MeteorCollidedWithShipEvent(){ Meteor = entity, Ship = x }));

        ProjectileObservableGroup
            .Where(x => meteorCollisionArea.Intersects(RuntimeColliders[x.Id]))
            .ForEachRun(x => EventSystem.Publish(new MeteorCollidedWithProjectileEvent(){ Meteor = entity, Projectile = x }));
    }

    public void BeforeProcessing()
    { RuntimeColliders.RefreshData(); }

    public void AfterProcessing()
    {}
}