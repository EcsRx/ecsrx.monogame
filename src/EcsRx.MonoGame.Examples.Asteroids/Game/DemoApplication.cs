using EcsRx.Extensions;
using EcsRx.MonoGame.Application;
using EcsRx.MonoGame.Examples.Asteroids.Blueprint;
using EcsRx.Plugins.Transforms;

namespace EcsRx.MonoGame.Examples.Asteroids.Game
{
    public class DemoApplication : EcsRxMonoGameApplication
    {
        protected override void LoadPlugins()
        {
            base.LoadPlugins();
            RegisterPlugin(new TransformsPlugin());
        }

        protected override void ApplicationStarted()
        {
            var defaultCollection = EntityDatabase.GetCollection();

            var shipEntity = defaultCollection.CreateEntity<ShipBlueprint>();
        }
    }
}