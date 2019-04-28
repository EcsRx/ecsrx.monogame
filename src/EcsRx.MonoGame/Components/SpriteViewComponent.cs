using EcsRx.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.Components
{
    public class SpriteComponent : IComponent
    {
        public Texture2D Sprite { get; set; }
        public Color Color { get; set; } = Color.White;
    }
}