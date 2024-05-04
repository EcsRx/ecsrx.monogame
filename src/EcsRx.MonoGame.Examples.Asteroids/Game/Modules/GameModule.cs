using Comora;
using EcsRx.MonoGame.Wrappers;
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
    }
}