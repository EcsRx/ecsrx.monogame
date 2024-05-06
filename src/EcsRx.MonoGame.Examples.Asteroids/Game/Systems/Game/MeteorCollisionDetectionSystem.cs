using System.Linq;
using EcsRx.Collections;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Groups.Observable;
using EcsRx.MonoGame.Examples.Asteroids.Extensions;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.MonoGame.Examples.Asteroids.Game.Computed;
using EcsRx.MonoGame.Examples.Asteroids.Game.Events;
using EcsRx.Plugins.Transforms.Components;
using EcsRx.Systems;
using Microsoft.Xna.Framework;
using SystemsRx.Events;
using SystemsRx.Extensions;
using SystemsRx.Scheduling;
using SystemsRx.Systems.Conventional;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Game;

public class MeteorCollisionDetectionSystem : IBasicEntitySystem, IBasicSystem
{
    public IGroup Group { get; } = new Group(typeof(MeteorComponent), typeof(ColliderComponent), typeof(Transform2DComponent));
    
    public IEventSystem EventSystem { get; }
    public IObservableGroup ShipObservableGroup { get; }
    public IObservableGroup ProjectileObservableGroup { get; }
    public ComputedRuntimeColliders RuntimeColliders { get; }

    public MeteorCollisionDetectionSystem(IObservableGroupManager observableGroupManager, IEventSystem eventSystem, ComputedRuntimeColliders runtimeColliders)
    {
        EventSystem = eventSystem;
        RuntimeColliders = runtimeColliders;
        ShipObservableGroup = observableGroupManager.GetObservableGroup(new Group(typeof(PlayerComponent), typeof(ColliderComponent), typeof(Transform2DComponent)));
        ProjectileObservableGroup = observableGroupManager.GetObservableGroup(new Group(typeof(ProjectileComponent), typeof(ColliderComponent), typeof(Transform2DComponent)));
    }
    
    public void Process(IEntity entity, ElapsedTime elapsedTime)
    {
        var meteorCollisionArea = RuntimeColliders[entity.Id];
        ShipObservableGroup
            .Where(x => meteorCollisionArea.Intersects(RuntimeColliders[x.Id]))
            .ForEachRun(x => EventSystem.PublishAsync(new MeteorCollidedWithShipEvent(){ Meteor = entity, Ship = x }));

        ProjectileObservableGroup
            .Where(x => meteorCollisionArea.Intersects(RuntimeColliders[x.Id]))
            .ForEachRun(x => EventSystem.PublishAsync(new MeteorCollidedWithProjectileEvent(){ Meteor = entity, Projectile = x }));
    }

    public void Execute(ElapsedTime elapsedTime)
    {
        RuntimeColliders.RefreshData();
    }
}