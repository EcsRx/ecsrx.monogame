using System;
using System.Reactive.Linq;
using EcsRx.Collections.Database;
using EcsRx.Collections.Entity;
using EcsRx.Extensions;
using EcsRx.MonoGame.Examples.Asteroids.Blueprint;
using EcsRx.MonoGame.Examples.Asteroids.Game.Blueprint;
using SystemsRx.Systems.Conventional;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Game;

public class MeteorSpawningSystem : IReactiveSystem<long>
{
    public IEntityCollection EntityCollection { get; }
    
    private double _elapsedTime;

    public MeteorSpawningSystem(IEntityDatabase entityDatabase)
    {
        EntityCollection = entityDatabase.GetCollection();
    }

    public IObservable<long> ReactTo() => Observable.Interval(TimeSpan.FromSeconds(2.0f));

    public void Execute(long _)
    {
        EntityCollection.CreateEntity<MeteorBlueprint>();
    }
}