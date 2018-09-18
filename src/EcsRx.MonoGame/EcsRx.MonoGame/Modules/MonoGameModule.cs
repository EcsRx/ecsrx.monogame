using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Extensions;
using EcsRx.MonoGame.Wrappers;

namespace EcsRx.MonoGame.Modules
{
    public class MonoGameModule : IDependencyModule
    {
        private readonly IGame _game;
        
        public MonoGameModule(IGame game)
        { _game = game; }

        public void Setup(IDependencyContainer container)
        {
            container.Bind<IGame>(x => x.ToInstance(_game));
            container.Bind<IGameScheduler>(x => x.ToInstance(_game));
            container.Bind<ISpriteBatch>(x => x.ToInstance(_game.SpriteBatch));
            container.Bind<IGraphicsDeviceManager>(x => x.ToInstance(_game.GraphicsDeviceManager as EcsRxGraphicsDeviceManager));
        }
    }
}