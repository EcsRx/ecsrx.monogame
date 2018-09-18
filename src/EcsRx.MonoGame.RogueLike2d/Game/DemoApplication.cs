using EcsRx.Extensions;
using EcsRx.MonoGame.Extensions;
using EcsRx.MonoGame.RogueLike2d.Components;
using EcsRx.MonoGame.RogueLike2d.Systems;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame.RogueLike2d
{
    public class DemoApplication : EcsRxMonoGameApplication
    {
        protected override void ApplicationStarting()
        {
            base.ApplicationStarting();

            this.BindAndRegisterSystem<LifecycleManagementSystem>();
            this.BindAndRegisterSystem<MovementSystem>();
            this.BindAndRegisterSystem<ShipDrawingSystem>();
        }

        protected override void ApplicationStarted()
        {
            var defaultCollection = EntityCollectionManager.GetCollection();

            var exampleEntity = defaultCollection.CreateEntity();
            var moveableComponent = exampleEntity.AddComponent<MoveableComponent>();

            moveableComponent.Position = new Vector2(100, 100);
            moveableComponent.MovementSpeed = 100.0f;
        }
    }
}