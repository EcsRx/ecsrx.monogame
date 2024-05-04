using System;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.Plugins.Transforms.Components;

namespace EcsRx.MonoGame.Examples.Asteroids.Groups
{
    public class ShipGroup : IGroup
    {
        public Type[] RequiredComponents { get; } = [typeof(PlayerComponent), typeof(ShootingComponent), typeof(ColliderComponent), typeof(HandlingComponent), typeof(MoveableComponent), typeof(SpriteComponent), typeof(Transform2DComponent)];
        public Type[] ExcludedComponents { get; } = Type.EmptyTypes;
    }
}