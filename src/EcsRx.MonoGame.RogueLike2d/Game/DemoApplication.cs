using EcsRx.MonoGame.Application;
using EcsRx.MonoGame.RogueLike2d.Blueprint;

namespace EcsRx.MonoGame.RogueLike2d.Game
{
    public class DemoApplication : EcsRxMonoGameApplication
    {
        protected override void ApplicationStarted()
        {
            var defaultCollection = EntityDatabase.GetCollection();

            var shipEntity = defaultCollection.CreateEntity(new ShipBlueprint());
        }
    }
}