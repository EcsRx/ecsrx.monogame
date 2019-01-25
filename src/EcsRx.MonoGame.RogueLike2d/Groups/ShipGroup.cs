using System;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.RogueLike2d.Game.Components;

namespace EcsRx.MonoGame.RogueLike2d.Groups
{
    public class ShipGroup : IGroup
    {
        public Type[] RequiredComponents { get; } = {typeof(MoveableComponent), typeof(SpriteComponent), typeof(ViewComponent2D)};
        public Type[] ExcludedComponents { get; } = new Type[0];
    }
}