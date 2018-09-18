using System;
using EcsRx.MonoGame.Wrappers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using IGraphicsDeviceManager = Microsoft.Xna.Framework.IGraphicsDeviceManager;

namespace EcsRx.MonoGame
{
    public interface IGame : IGameScheduler
    {
        IObservable<bool> GameLoading { get; }
        IObservable<bool> GameUnloading { get; }
        IGraphicsDeviceManager GraphicsDeviceManager { get; }
        ISpriteBatch SpriteBatch { get; }
        LaunchParameters LaunchParameters { get; }
        GameComponentCollection Components { get; }
        TimeSpan InactiveSleepTime { get; }
        TimeSpan MaxElapsedTime { get; }
        bool IsActive { get; }
        bool IsMouseVisible { get; set; }
        TimeSpan TargetElapsedTime { get; }
        bool IsFixedTimeStep { get; set; }
        GameServiceContainer Services { get; }
        IContentManager ContentManager { get; }
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