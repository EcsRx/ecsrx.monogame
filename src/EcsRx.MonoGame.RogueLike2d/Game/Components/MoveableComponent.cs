using EcsRx.Components;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame.RogueLike2d.Components
{
    public class MoveableComponent : IComponent
    {
        public Vector2 Position { get; set; }
        public float MovementSpeed { get; set; }
    }
}