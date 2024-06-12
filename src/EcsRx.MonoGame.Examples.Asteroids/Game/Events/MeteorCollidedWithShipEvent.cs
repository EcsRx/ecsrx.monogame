using EcsRx.Entities;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Events;

public class MeteorCollidedWithShipEvent
{
    public IEntity Meteor { get; set; }
    public IEntity Ship { get; set; }
}