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
        protected override IDependencyContainer DependencyContainer { get; } = new NinjectDependencyContainer();
        public IDependencyContainer DIContainer => DependencyContainer;

        protected IEcsRxGame EcsRxGame { get; }
        protected IEcsRxContentManager EcsRxContentManager => EcsRxGame.EcsRxContentManager;
        protected IEcsRxGraphicsDeviceManager DeviceManager => EcsRxGame.EcsRxGraphicsDeviceManager;

        public EcsRxMonoGameApplication()
        {
            EcsRxGame = new EcsRxEcsRxGame();
            EcsRxGame.GameLoading.FirstAsync().Subscribe(x => StartApplication());
            EcsRxGame.Run();
        }

        protected override void RegisterModules()
        {
            DependencyContainer.LoadModule(new MonoGameModule(EcsRxGame));
            base.RegisterModules();
        }

        public void Dispose()
        {
            EcsRxGame.Dispose();
        }
    }
}