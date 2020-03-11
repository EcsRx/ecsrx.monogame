using System;
using EcsRx.Scheduling;

namespace EcsRx.MonoGame
{
    public interface IGameScheduler : IUpdateScheduler
    {
        IObservable<ElapsedTime> OnPreRender { get; }
        IObservable<ElapsedTime> OnRender { get; }
        IObservable<ElapsedTime> OnPostRender { get; }
    }
}