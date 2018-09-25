using EcsRx.MonoGame.Models;
using EcsRx.Views.Components;

namespace EcsRx.MonoGame.Components
{
    public class ViewComponent2D : ViewComponent
    {
        public Transform2D Transform { get; set; } = new Transform2D();
    }
}