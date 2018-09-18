using EcsRx.Infrastructure;
using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Ninject;
using EcsRx.MicroRx.Extensions;
using EcsRx.MonoGame.Modules;

namespace EcsRx.MonoGame
{
    public abstract class EcsRxMonoGameApplication : EcsRxApplication
    {
        protected override IDependencyContainer DependencyContainer { get; } = new NinjectDependencyContainer();
        
        public IGame Game { get; }

        public EcsRxMonoGameApplication()
        {
            Game = new EcsRxGame();
            Game.GameLoading.Subscribe(x => StartApplication());
        }

        protected override void RegisterModules()
        {
            base.RegisterModules();
            DependencyContainer.LoadModule(new MonoGameModule(Game));
        }
    }
}