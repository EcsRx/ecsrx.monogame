using EcsRx.Components;
using EcsRx.MonoGame.Components;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame.RogueLike2d.Components
{
    public class MoveableComponent : IComponent
    {
        public float MovementSpeed { get; set; }
    }
}