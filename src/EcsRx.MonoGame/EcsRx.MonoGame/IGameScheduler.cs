using System;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame
{
    public interface IGameScheduler
    {
        IObservable<GameTime> EveryUpdate { get; }
        IObservable<GameTime> EveryRender { get; }
    }
}