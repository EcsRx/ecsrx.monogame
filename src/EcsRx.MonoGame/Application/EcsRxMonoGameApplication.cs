using System;
using System.Reactive.Linq;
using SystemsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure;
using EcsRx.Infrastructure.Ninject;
using EcsRx.MonoGame.Modules;
using EcsRx.MonoGame.Wrappers;
using EcsRx.Plugins.ReactiveSystems;
using EcsRx.Plugins.Views;
using EcsRx.Plugins.Views.Extensions;

namespace EcsRx.MonoGame.Application
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
            StartGame();
        }

        protected void StartGame()
        {
            BeforeGameStarted();
            EcsRxGame.GameLoading.FirstAsync().Subscribe(x => StartApplication());
            EcsRxGame.Run();
        }

        protected virtual void BeforeGameStarted()
        {}

        protected override void StartSystems()
        { this.StartAllBoundViewSystems(); }

        protected override void LoadPlugins()
        {
            RegisterPlugin(new ReactiveSystemsPlugin());
            RegisterPlugin(new ViewsPlugin());
        }

        protected override void LoadModules()
        {
            base.LoadModules();
            Container.LoadModule(new MonoGameModule(EcsRxGame));
        }
        
        public void Dispose()
        { EcsRxGame.Dispose(); }
    }
}