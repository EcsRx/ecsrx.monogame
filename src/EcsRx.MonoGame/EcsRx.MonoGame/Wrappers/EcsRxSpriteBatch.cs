using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.Wrappers
{
    public class EcsRxSpriteBatch : SpriteBatch, ISpriteBatch
    {
        public EcsRxSpriteBatch(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {}
    }
}