using EcsRx.Entities;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Events;

public class MeteorCollidedWithProjectileEvent
{
    public IEntity Meteor { get; set; }
    public IEntity Projectile { get; set; }
}