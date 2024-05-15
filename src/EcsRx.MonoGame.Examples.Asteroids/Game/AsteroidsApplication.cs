using EcsRx.Extensions;
using EcsRx.MonoGame.Application;
using EcsRx.MonoGame.Examples.Asteroids.Game.Blueprint;
using EcsRx.MonoGame.Examples.Asteroids.Game.Modules;
using EcsRx.Plugins.Computeds;
using EcsRx.Plugins.Transforms;
using SystemsRx.Infrastructure.Extensions;

namespace EcsRx.MonoGame.Examples.Asteroids.Game
{
    public class AsteroidsApplication : EcsRxMonoGameApplication
    {
        protected override void LoadModules()
        {
            base.LoadModules();
            DependencyRegistry.LoadModule<GameModule>();
        }

        protected override void LoadPlugins()
        {
            base.LoadPlugins();
            RegisterPlugin(new TransformsPlugin());
            RegisterPlugin(new ComputedsPlugin());
        }

        protected override void ApplicationStarted()
        {
            var defaultCollection = EntityDatabase.GetCollection();
            defaultCollection.CreateEntity<ShipBlueprint>();
        }
    }
}