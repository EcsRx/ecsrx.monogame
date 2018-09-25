using System;
using System.Reactive.Linq;
using EcsRx.Infrastructure;
using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Ninject;
using EcsRx.MonoGame.Modules;
using EcsRx.MonoGame.Wrappers;

namespace EcsRx.MonoGame
{
    public abstract class EcsRxMonoGameApplication : EcsRxApplication, IDisposable
    {
        public override IDependencyContainer Container { get; } = new NinjectDependencyContainer();

        protected IEcsRxGame EcsRxGame { get; }
        protected IEcsRxContentManager EcsRxContentManager => EcsRxGame.EcsRxContentManager;
        protected IEcsRxGraphicsDeviceManager DeviceManager => EcsRxGame.EcsRxGraphicsDeviceManager;

        public EcsRxMonoGameApplication()
        {
            EcsRxGame = new EcsRxGame();
            EcsRxGame.GameLoading.FirstAsync().Subscribe(x => StartApplication());
            EcsRxGame.Run();
        }

        protected override void LoadModules()
        {
            Container.LoadModule(new MonoGameModule(EcsRxGame));
            base.LoadModules();
        }
        
        public void Dispose()
        { EcsRxGame.Dispose(); }
    }
}