using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.Wrappers
{
    public class EcsRxSpriteBatch : SpriteBatch, IEcsRxSpriteBatch
    {
        public EcsRxSpriteBatch(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {}
    }
}