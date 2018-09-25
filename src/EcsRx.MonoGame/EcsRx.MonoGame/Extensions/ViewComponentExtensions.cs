using EcsRx.MonoGame.Components;
using EcsRx.MonoGame.Models;

namespace EcsRx.MonoGame.Extensions
{
    public static class ViewComponentExtensions
    {
        public static Transform2D GetTransform(this ViewComponent2D viewComponent)
        { return viewComponent.View as Transform2D; }
        
        public static Transform GetTransform(this ViewComponent3D viewComponent)
        { return viewComponent.View as Transform; }
    }
}