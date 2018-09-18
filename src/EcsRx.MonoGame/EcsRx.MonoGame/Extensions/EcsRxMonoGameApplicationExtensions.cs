using System.Linq;
using EcsRx.Extensions;
using EcsRx.Infrastructure.Dependencies;
using EcsRx.Systems;
using EcsRx.Views.Systems;

namespace EcsRx.MonoGame.Extensions
{
    public static class EcsRxMonoGameApplicationExtensions
    {
        /// <summary>
        /// This will register all ISystem implementations within the DI container
        /// with the SystemExecutor.
        /// </summary>
        /// <param name="application">The application to act on</param>
        public static void RegisterAllBoundSystems(this EcsRxMonoGameApplication application)
        {
            var allSystems = application.DIContainer.ResolveAll<ISystem>();

            var orderedSystems = allSystems
                .OrderByDescending(x => x is ViewResolverSystem)
                .ThenByDescending(x => x is ISetupSystem)
                .ThenByPriority();

            orderedSystems.ForEachRun(application.SystemExecutor.AddSystem);
        }
        
        /// <summary>
        /// This will bind the given system type (T) to the DI container against `ISystem`
        /// and will then immediately register the system with the SystemExecutor.
        /// </summary>
        /// <param name="application">The application to act on</param>
        /// <typeparam name="T">The implementation of ISystem to bind/register</typeparam>
        public static void BindAndRegisterSystem<T>(this EcsRxMonoGameApplication application) where T : ISystem
        {
            application.DIContainer.Bind<ISystem, T>(new BindingConfiguration{WithName = typeof(T).Name});
            RegisterSystem<T>(application);
        }
        
        /// <summary>
        /// This will resolve the given type (T) from the DI container then register it
        /// with the SystemExecutor.
        /// </summary>
        /// <param name="application">The application to act on</param>
        /// <typeparam name="T">The implementation of ISystem to register</typeparam>
        public static void RegisterSystem<T>(this EcsRxMonoGameApplication application) where T : ISystem
        {
            var system = application.DIContainer.Resolve<T>();
            application.SystemExecutor.AddSystem(system);
        }
    }
}