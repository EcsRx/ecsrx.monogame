using SystemsRx.Executor.Handlers;
using SystemsRx.Infrastructure.Dependencies;
using SystemsRx.Infrastructure.Extensions;
using SystemsRx.Scheduling;
using EcsRx.MonoGame.Rendering;
using EcsRx.MonoGame.Systems.Handlers;
using EcsRx.MonoGame.Wrappers;

namespace EcsRx.MonoGame.Modules
{
    public class MonoGameModule : IDependencyModule
    {
        private readonly IEcsRxGame _ecsRxGame;
        
        public MonoGameModule(IEcsRxGame ecsRxGame)
        { _ecsRxGame = ecsRxGame; }

        public void Setup(IDependencyRegistry registry)
        {
            registry.Bind<IEcsRxGame>(x => x.ToInstance(_ecsRxGame));

            registry.Unbind<IUpdateScheduler>();
            registry.Bind<IUpdateScheduler>(x => x.ToInstance(_ecsRxGame));
            registry.Bind<IGameScheduler>(x => x.ToInstance(_ecsRxGame));
            
            registry.Bind<IEcsRxContentManager>(x => x.ToInstance(_ecsRxGame.EcsRxContentManager));
            registry.Bind<IEcsRxSpriteBatch>(x => x.ToInstance(_ecsRxGame.EcsRxSpriteBatch));
            registry.Bind<IEcsRxGraphicsDeviceManager>(x => x.ToInstance(_ecsRxGame.EcsRxGraphicsDeviceManager));
            registry.Bind<IEcsRxGraphicsDevice>(x => x.ToInstance(_ecsRxGame.EcsRxGraphicsDevice));

            registry.Bind<IRenderTarget2dRegistry, RenderTarget2dRegistry>();
            registry.Bind<IRenderTargetCubeRegistry, RenderTargetCubeRegistry>();
            
            registry.Bind<IConventionalSystemHandler, SpriteBatchSystemHandler>();
        }
    }
}