using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame.Models
{
    public class Transform2D
    {
        public Vector2 Position { get; set; } = Vector2.Zero;
        public float Angle { get; set; } = 0.0f;
        public Vector2 Scale { get; set; } = Vector2.One;
    }
}