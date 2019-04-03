using System;
using System.Collections.Generic;
using System.Linq;
using EcsRx.Attributes;
using EcsRx.Collections;
using EcsRx.Entities;
using EcsRx.Executor.Handlers;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Systems;

namespace EcsRx.MonoGame.Systems.Handlers
{   
    [Priority(6)]
    public class SpriteBatchSystemHandler : IConventionalSystemHandler
    {
        public readonly IEntityCollectionManager EntityCollectionManager;       
        public readonly IDictionary<ISystem, IDisposable> _systemSubscriptions;
        public readonly IGameScheduler _gameScheduler;
        
        public SpriteBatchSystemHandler(IEntityCollectionManager entityCollectionManager, IGameScheduler scheduler)
        {
            EntityCollectionManager = entityCollectionManager;
            _systemSubscriptions = new Dictionary<ISystem, IDisposable>();
            _gameScheduler = scheduler;
       }

        public bool CanHandleSystem(ISystem system)
        { return system.GetType().IsSubclassOf(typeof(SpriteBatchSystem)) ; }
       
        public void SetupSystem(ISystem system)
        {
            var observableGroup = EntityCollectionManager.GetObservableGroup(system.Group);
            var hasEntityPredicate = system.Group is IHasPredicate;
            var castSystem = (SpriteBatchSystem)system;

            var drawSubscription = _gameScheduler.OnRender.Subscribe(x =>
            {
                castSystem.PreDraw();
                
                if(!hasEntityPredicate)
                { ExecuteForGroup(observableGroup, castSystem); }
                else
                {
                    var groupPredicate = system.Group as IHasPredicate;
                    ExecuteForGroup(observableGroup.Where(groupPredicate.CanProcessEntity), castSystem);
                }
                
                castSystem.PostDraw();
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