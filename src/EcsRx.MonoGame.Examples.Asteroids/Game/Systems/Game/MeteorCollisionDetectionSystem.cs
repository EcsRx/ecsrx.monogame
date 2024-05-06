using System.Linq;
using EcsRx.Collections;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Groups.Observable;
using EcsRx.MonoGame.Examples.Asteroids.Extensions;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.Plugins.Transforms.Components;
using EcsRx.Systems;
using Microsoft.Xna.Framework;
using SystemsRx.Events;
using SystemsRx.Extensions;
using SystemsRx.Scheduling;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Game;

public class MeteorCollisionDetectionSystem : IBasicEntitySystem
{
    public IGroup Group { get; } = new Group(typeof(MeteorComponent), typeof(ColliderComponent), typeof(Transform2DComponent));
    
    public IEventSystem EventSystem { get; }
    public IObservableGroup ShipObservableGroup { get; }
    public IObservableGroup ProjectileObservableGroup { get; }

    public MeteorCollisionDetectionSystem(IObservableGroupManager observableGroupManager, IEventSystem eventSystem)
    {
        EventSystem = eventSystem;
        ShipObservableGroup = observableGroupManager.GetObservableGroup(new Group(typeof(PlayerComponent), typeof(ColliderComponent), typeof(Transform2DComponent)));
        ProjectileObservableGroup = observableGroupManager.GetObservableGroup(new Group(typeof(ProjectileComponent), typeof(ColliderComponent), typeof(Transform2DComponent)));
    }

    public void Process(IEntity entity, ElapsedTime elapsedTime)
    {
        var meteorCollisionArea = GenerateCollisionArea(entity);
        ShipObservableGroup.ForEachRun(x => CheckForShipCollision(meteorCollisionArea, x));

    }

    public Rectangle GenerateCollisionArea(IEntity entity)
    {
        var colliderComponent = entity.GetComponent<ColliderComponent>();
        var transformComponent = entity.GetComponent<Transform2DComponent>();
        return transformComponent.Transform.GetCollisionArea(colliderComponent);
    }

    public bool CheckForShipCollision(Rectangle meteorCollisionArea, IEntity shipEntity)
    {
        var shipCollider = shipEntity.GetComponent<ColliderComponent>();
        
    }
}