using System;
using EcsRx.Scheduling;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame
{
    public interface IGameScheduler : IObservableScheduler
    {
        IObservable<TimeSpan> OnPreUpdate { get; }
        IObservable<TimeSpan> OnPostUpdate { get; }
    
        IObservable<TimeSpan> OnPreRender { get; }
        IObservable<TimeSpan> OnRender { get; }
        IObservable<TimeSpan> OnPostRender { get; }
        
        GameTime GameTime { get; }
    }
}