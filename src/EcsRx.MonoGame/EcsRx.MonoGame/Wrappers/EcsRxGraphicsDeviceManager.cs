using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame.Wrappers
{
    public class EcsRxGraphicsDeviceManager : GraphicsDeviceManager, IEcsRxGraphicsDeviceManager
    {
        public EcsRxGraphicsDeviceManager(Game game) : base(game)
        {}
    }
}