using System;
using System.Reactive.Linq;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups.Observable;
using EcsRx.MonoGame.Examples.Asteroids.Extensions;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.Plugins.Computeds.Collections;
using EcsRx.Plugins.Transforms.Components;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Computed;

public class ComputedRuntimeColliders : ComputedCollectionFromGroup<(int entityId, Rectangle collisionArea)>
{
    public ComputedRuntimeColliders(IObservableGroup internalObservableGroup) : base(internalObservableGroup)
    {}

    public override IObservable<bool> RefreshWhen()
    { return Observable.Never<bool>(); }

    public override bool ShouldTransform(IEntity entity) => true;
    
    public override (int entityId, Rectangle collisionArea) Transform(IEntity entity)
    {
        var collisionArea = GenerateCollisionArea(entity);
        return (entity.Id, collisionArea);
    }
    
    public Rectangle GenerateCollisionArea(IEntity entity)
    {
        var colliderComponent = entity.GetComponent<ColliderComponent>();
        var transformComponent = entity.GetComponent<Transform2DComponent>();
        return transformComponent.Transform.GetCollisionArea(colliderComponent);
    }
}