using EcsRx.Executor.Handlers;
using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Extensions;
using EcsRx.MonoGame.Systems.Handlers;
using EcsRx.MonoGame.Wrappers;

namespace EcsRx.MonoGame.Modules
{
    public class MonoGameModule : IDependencyModule
    {
        private readonly IEcsRxGame _ecsRxGame;
        
        public MonoGameModule(IEcsRxGame ecsRxGame)
        { _ecsRxGame = ecsRxGame; }

        public void Setup(IDependencyContainer container)
        {
            container.Bind<IEcsRxGame>(x => x.ToInstance(_ecsRxGame));
            container.Bind<IGameScheduler>(x => x.ToInstance(_ecsRxGame));
            container.Bind<IEcsRxContentManager>(x => x.ToInstance(_ecsRxGame.EcsRxContentManager));
            container.Bind<IEcsRxSpriteBatch>(x => x.ToInstance(_ecsRxGame.EcsRxSpriteBatch));
            container.Bind<IEcsRxGraphicsDeviceManager>(x => x.ToInstance(_ecsRxGame.EcsRxGraphicsDeviceManager));
            container.Bind<IEcsRxGraphicsDevice>(x => x.ToInstance(_ecsRxGame.EcsRxGraphicsDevice));
            
            container.Bind<IConventionalSystemHandler, SpriteBatchSystemHandler>();
        }
    }
}