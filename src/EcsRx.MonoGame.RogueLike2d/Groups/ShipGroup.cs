using System;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.RogueLike2d.Game.Components;
using EcsRx.Plugins.Transforms.Components;

namespace EcsRx.MonoGame.RogueLike2d.Groups
{
    public class ShipGroup : IGroup
    {
        public Type[] RequiredComponents { get; } = [typeof(MoveableComponent), typeof(SpriteComponent), typeof(Transform2DComponent)];
        public Type[] ExcludedComponents { get; } = Type.EmptyTypes;
    }
}