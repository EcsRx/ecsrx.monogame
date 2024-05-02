using System.Numerics;
using EcsRx.Components;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Components
{
    public class MoveableComponent : IComponent
    {
        public Vector2 MovementChange { get; set; }
        public float DirectionChange { get; set; }
    }
}