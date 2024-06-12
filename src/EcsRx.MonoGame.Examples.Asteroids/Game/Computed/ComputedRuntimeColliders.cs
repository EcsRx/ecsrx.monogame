using System;
using System.Reactive.Linq;
using EcsRx.Computeds.Collections;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups.Observable;
using EcsRx.MonoGame.Examples.Asteroids.Extensions;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.Plugins.Transforms.Components;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Computed;

public class ComputedRuntimeColliders : ComputedCollectionFromGroup<Rectangle>
{
    public ComputedRuntimeColliders(IObservableGroup internalObservableGroup) : base(internalObservableGroup)
    {}

    public override IObservable<bool> RefreshWhen()
    { return Observable.Never<bool>(); }

    public override bool ShouldTransform(IEntity entity) => true;
    
    public override Rectangle Transform(IEntity entity) => GenerateCollisionArea(entity);
    
    public Rectangle GenerateCollisionArea(IEntity entity)
    {
        var colliderComponent = entity.GetComponent<ColliderComponent>();
        var transformComponent = entity.GetComponent<Transform2DComponent>();
        return transformComponent.Transform.GetCollisionArea(colliderComponent);
    }
}