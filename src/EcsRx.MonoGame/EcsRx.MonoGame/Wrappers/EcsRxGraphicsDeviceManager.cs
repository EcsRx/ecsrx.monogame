using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame.Wrappers
{
    public class EcsRxEcsRxGraphicsDeviceManager : GraphicsDeviceManager, IEcsRxGraphicsDeviceManager
    {
        public EcsRxEcsRxGraphicsDeviceManager(Game game) : base(game)
        {}
    }
}