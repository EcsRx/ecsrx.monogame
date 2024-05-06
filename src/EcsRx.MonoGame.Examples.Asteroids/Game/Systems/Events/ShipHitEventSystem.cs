using EcsRx.Collections.Database;
using EcsRx.Collections.Entity;
using EcsRx.Extensions;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.MonoGame.Examples.Asteroids.Game.Events;
using SystemsRx.Systems.Conventional;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Events;

public class ShipHitEventSystem : IReactToEventSystem<MeteorCollidedWithShipEvent>
{
    public IEntityCollection EntityCollection { get; }

    public ShipHitEventSystem(IEntityDatabase entityDatabase)
    {
        EntityCollection = entityDatabase.GetCollection();
    }

    public void Process(MeteorCollidedWithShipEvent eventData)
    {
        var playerComponent = eventData.Ship.GetComponent<PlayerComponent>();
        playerComponent.Score -= 500;

        if (playerComponent.Score < 0)
        { playerComponent.Score = 0; }
        
        EntityCollection.RemoveEntity(eventData.Meteor.Id);
    }
}