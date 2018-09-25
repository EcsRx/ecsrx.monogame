using EcsRx.Blueprints;
using EcsRx.Entities;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.RogueLike2d.Components;

namespace EcsRx.MonoGame.RogueLike2d.Blueprint
{
    public class ShipBlueprint : IBlueprint
    {
        public void Apply(IEntity entity)
        {
            entity.AddComponents(new MoveableComponent(), new SpriteComponent(), new ViewComponent2D());
        }
    }
}