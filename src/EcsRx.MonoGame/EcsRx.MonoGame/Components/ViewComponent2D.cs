using EcsRx.MonoGame.Models;
using EcsRx.Plugins.Views.Components;

namespace EcsRx.MonoGame.Components
{
    public class ViewComponent2D : ViewComponent
    {
        public ViewComponent2D()
        { View = new Transform2D(); }
    }
}