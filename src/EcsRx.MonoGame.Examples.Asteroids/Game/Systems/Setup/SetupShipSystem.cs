using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.MonoGame.Wrappers;
using EcsRx.Plugins.Transforms.Components;
using EcsRx.Systems;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = System.Numerics.Vector2;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Systems.Setup;

public class SetupShipSystem : ISetupSystem
{
    public IGroup Group { get; } = new Group(typeof(PlayerComponent), typeof(SpriteComponent), typeof(Transform2DComponent), typeof(SpriteComponent));
        
    public IEcsRxContentManager ContentManager { get; }
    public IEcsRxGraphicsDevice GraphicsDevice { get; }

    public SetupShipSystem(IEcsRxContentManager contentManager, IEcsRxGraphicsDevice graphicsDevice)
    {
        ContentManager = contentManager;
        GraphicsDevice = graphicsDevice;
    }

    public void Setup(IEntity entity)
    {
        var spriteComponent = entity.GetComponent<SpriteComponent>();
        spriteComponent.Sprite = ContentManager.Load<Texture2D>("ship");
            
        var colliderComponent = entity.GetComponent<ColliderComponent>();
        colliderComponent.Width = spriteComponent.Sprite.Width;
        colliderComponent.Height = spriteComponent.Sprite.Height;

        var screenCenterX = GraphicsDevice.Viewport.Width/2;
        var screenCenterY = GraphicsDevice.Viewport.Height/2;
        var viewComponent = entity.GetComponent<Transform2DComponent>();
        viewComponent.Transform.Position = new Vector2(0, 0);
    }
}