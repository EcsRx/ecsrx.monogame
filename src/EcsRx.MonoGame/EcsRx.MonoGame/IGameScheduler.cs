using System;
using EcsRx.Infrastructure.Scheduling;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame
{
    public interface IGameScheduler : IObservableScheduler
    {
        IObservable<TimeSpan> OnPreRender { get; }
        IObservable<TimeSpan> OnRender { get; }
        IObservable<TimeSpan> OnPostRender { get; }
        
        GameTime GameTime { get; }
    }
}