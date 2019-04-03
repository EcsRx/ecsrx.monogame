using System;
using EcsRx.Infrastructure.Scheduling;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame
{
    public interface IGameScheduler : IObservableScheduler
    {
        IObservable<TimeSpan> OnRender { get; }
        GameTime GameTime { get; }
    }
}