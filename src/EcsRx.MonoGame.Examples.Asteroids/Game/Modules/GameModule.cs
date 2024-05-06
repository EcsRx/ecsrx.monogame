using Comora;
using EcsRx.Infrastructure.Extensions;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using EcsRx.MonoGame.Examples.Asteroids.Game.Computed;
using EcsRx.MonoGame.Wrappers;
using EcsRx.Plugins.Transforms.Components;
using SystemsRx.Infrastructure.Dependencies;
using SystemsRx.Infrastructure.Extensions;

namespace EcsRx.MonoGame.Examples.Asteroids.Game.Modules;

public class GameModule : IDependencyModule
{
    public void Setup(IDependencyRegistry registry)
    {
        registry.Bind<ICamera>(x => x.ToMethod(resolver =>
        {
            var ecsRxGraphicsDevice = resolver.Resolve<IEcsRxGraphicsDevice>();
            return new Camera(ecsRxGraphicsDevice.InternalDevice);
        }));

        registry.Bind<ComputedRuntimeColliders>(x => x.ToMethod(resolver =>
        {
            var observableGroup =
                resolver.ResolveObservableGroup(typeof(ColliderComponent), typeof(Transform2DComponent));
            return new ComputedRuntimeColliders(observableGroup);
        }));
    }
}