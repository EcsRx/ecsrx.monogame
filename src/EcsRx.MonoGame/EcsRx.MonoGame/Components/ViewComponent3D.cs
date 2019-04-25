using EcsRx.MonoGame.Models;
using EcsRx.Plugins.Views.Components;

namespace EcsRx.MonoGame.Components
{
    public class ViewComponent3D : ViewComponent
    {
        public ViewComponent3D()
        { View = new Transform(); }
    }
}