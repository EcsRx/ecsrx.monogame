using System;
using System.Reactive;
using EcsRx.MonoGame.Wrappers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame
{
    public interface IEcsRxGame : IGameScheduler
    {
        IObservable<Unit> GameLoading { get; }
        IObservable<Unit> GameUnloading { get; }
        IEcsRxGraphicsDeviceManager EcsRxGraphicsDeviceManager { get; }
        IEcsRxSpriteBatch EcsRxSpriteBatch { get; }
        IEcsRxGraphicsDevice EcsRxGraphicsDevice { get; }
        LaunchParameters LaunchParameters { get; }
        GameComponentCollection Components { get; }
        TimeSpan InactiveSleepTime { get; }
        TimeSpan MaxElapsedTime { get; }
        bool IsActive { get; }
        bool IsMouseVisible { get; set; }
        TimeSpan TargetElapsedTime { get; }
        bool IsFixedTimeStep { get; set; }
        GameServiceContainer Services { get; }
        IEcsRxContentManager EcsRxContentManager { get; }
        GraphicsDevice GraphicsDevice { get; }
        GameWindow Window { get; }
        void Dispose();
        void Exit();
        void ResetElapsedTime();
        void SuppressDraw();
        void RunOneFrame();
        void Run();
        void Run(GameRunBehavior runBehavior);
        void Tick();
        event EventHandler<EventArgs> Activated;
        event EventHandler<EventArgs> Deactivated;
        event EventHandler<EventArgs> Disposed;
        event EventHandler<EventArgs> Exiting;
    }
}