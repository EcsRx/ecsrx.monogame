using System;
using System.Collections.Generic;
using System.Linq;
using SystemsRx.Attributes;
using SystemsRx.Executor.Handlers;
using SystemsRx.Extensions;
using SystemsRx.Systems;
using EcsRx.Collections;
using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.MonoGame.Extensions;
using EcsRx.MonoGame.Rendering;
using EcsRx.MonoGame.Wrappers;

namespace EcsRx.MonoGame.Systems.Handlers
{   
    [Priority(6)]
    public class SpriteBatchSystemHandler : IConventionalSystemHandler
    {
        public readonly IObservableGroupManager ObservableGroupManager;       
        public readonly IDictionary<ISystem, IDisposable> _systemSubscriptions;
        public readonly IGameScheduler _gameScheduler;
        public readonly IEcsRxGraphicsDevice _graphicsDevice;
        public readonly IRenderTarget2dRegistry _renderTarget2dRegistry;
        
        public SpriteBatchSystemHandler(IObservableGroupManager observableGroupManager, IEcsRxGraphicsDevice graphicsDevice, IRenderTarget2dRegistry renderTarget2dRegistry, IGameScheduler scheduler)
        {
            ObservableGroupManager = observableGroupManager;
            _systemSubscriptions = new Dictionary<ISystem, IDisposable>();
            _graphicsDevice = graphicsDevice;
            _gameScheduler = scheduler;
            _renderTarget2dRegistry = renderTarget2dRegistry;
        }

        public bool CanHandleSystem(ISystem system)
        { return system.GetType().IsSubclassOf(typeof(SpriteBatchSystem)) ; }
       
        public void SetupSystem(ISystem system)
        {
            var castSystem = (SpriteBatchSystem)system;
            var observableGroup = ObservableGroupManager.GetObservableGroup(castSystem.Group);
            var hasEntityPredicate = castSystem.Group is IHasPredicate;
            var renderTargetId = castSystem.GetRenderTexture2dId();
            var currentRenderTargets = _graphicsDevice.GetRenderTargets();

            var drawSubscription = _gameScheduler.OnRender.Subscribe(x =>
            {
                if (renderTargetId >= 0)
                {
                    var renderTarget = _renderTarget2dRegistry.GetRenderTarget(renderTargetId);
                    _graphicsDevice.SetRenderTarget(renderTarget);
                }
                
                castSystem.PreDraw();
                
                if(!hasEntityPredicate)
                { ExecuteForGroup(observableGroup, castSystem); }
                else
                {
                    var groupPredicate = castSystem.Group as IHasPredicate;
                    ExecuteForGroup(observableGroup.Where(groupPredicate.CanProcessEntity), castSystem);
                }
                
                castSystem.PostDraw();

                if (renderTargetId >= 0)
                {
                    _graphicsDevice.SetRenderTargets(currentRenderTargets);
                }
            });
            
            _systemSubscriptions.Add(system, drawSubscription);
        }

        private static void ExecuteForGroup(IEnumerable<IEntity> entities, SpriteBatchSystem castSystem)
        {
            foreach(var entity in entities)
            { castSystem.Process(entity); }
        }

        public void DestroySystem(ISystem system)
        { _systemSubscriptions.RemoveAndDispose(system); }

        public void Dispose()
        {
            _systemSubscriptions.Values.DisposeAll();
            _systemSubscriptions.Clear();
        }
    }
}