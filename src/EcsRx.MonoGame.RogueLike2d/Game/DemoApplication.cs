using EcsRx.Extensions;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Extensions;
using EcsRx.MonoGame.RogueLike2d.Blueprint;
using EcsRx.MonoGame.RogueLike2d.Components;
using EcsRx.MonoGame.RogueLike2d.Systems;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame.RogueLike2d
{
    public class DemoApplication : EcsRxMonoGameApplication
    {
        protected override void ApplicationStarted()
        {
            var defaultCollection = EntityCollectionManager.GetCollection();

            var shipEntity = defaultCollection.CreateEntity(new ShipBlueprint());
        }
    }
}