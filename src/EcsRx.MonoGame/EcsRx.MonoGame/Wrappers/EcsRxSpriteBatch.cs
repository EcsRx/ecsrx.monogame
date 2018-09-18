using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.Wrappers
{
    public class EcsRxEcsRxSpriteBatch : SpriteBatch, IEcsRxSpriteBatch
    {
        public EcsRxEcsRxSpriteBatch(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {}
    }
}