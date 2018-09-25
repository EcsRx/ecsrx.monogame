using EcsRx.MonoGame.Models;
using EcsRx.Views.Components;

namespace EcsRx.MonoGame.Components
{
    public class ViewComponent3D : ViewComponent
    {
        public Transform Transform { get; set; } = new Transform();
    }
}