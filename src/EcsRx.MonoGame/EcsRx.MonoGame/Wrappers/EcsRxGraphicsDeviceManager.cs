using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame.Wrappers
{
    public class EcsRxGraphicsDeviceManager : GraphicsDeviceManager, IGraphicsDeviceManager
    {
        public EcsRxGraphicsDeviceManager(Game game) : base(game)
        {}
    }
}