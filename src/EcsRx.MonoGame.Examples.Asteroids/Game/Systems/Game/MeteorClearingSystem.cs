using EcsRx.Collections.Database;
using EcsRx.Collections.Entity;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.Systems;
using SystemsRx.Scheduling;
using SystemsRx.Systems.Conventional;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Game;

public class MeteorClearingSystem : IBasicEntitySystem
{
    public float MaxAliveTime = 10.0f;
    
    public IGroup Group { get; } = new Group(typeof(MeteorComponent));
    public IEntityCollection EntityCollection { get; }

    public MeteorClearingSystem(IEntityDatabase entityDatabase)
    {
        EntityCollection = entityDatabase.GetCollection();
    }

    public void Process(IEntity entity, ElapsedTime elapsedTime)
    {
        var meteorComponent = entity.GetComponent<MeteorComponent>();
        meteorComponent.AliveTime += (float)elapsedTime.DeltaTime.TotalSeconds;

        if (meteorComponent.AliveTime >= MaxAliveTime)
        { EntityCollection.RemoveEntity(entity.Id); }
    }
}