using EcsRx.MonoGame.Application;
using EcsRx.MonoGame.RogueLike2d.Blueprint;
using EcsRx.Plugins.Transforms;

namespace EcsRx.MonoGame.RogueLike2d.Game
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

            var shipEntity = defaultCollection.CreateEntity(new ShipBlueprint());
        }
    }
}