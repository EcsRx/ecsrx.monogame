using System;
using System.Reactive;
using System.Reactive.Linq;
using EcsRx.MicroRx.Subjects;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame.Wrappers
{
    public class EcsRxGame : Game, IEcsRxGame
    {
        private readonly Subject<TimeSpan> _everyUpdate, _everyRender;
        private readonly Subject<Unit> _gameLoading;

        public IObservable<TimeSpan> OnUpdate => _everyUpdate;
        public IObservable<TimeSpan> OnRender => _everyRender;
        public IObservable<Unit> GameLoading => _gameLoading;
        public IObservable<Unit> GameUnloading { get; }
        
        public IEcsRxGraphicsDeviceManager EcsRxGraphicsDeviceManager { get; }
        public IEcsRxGraphicsDevice EcsRxGraphicsDevice { get; private set; }
        public IEcsRxSpriteBatch EcsRxSpriteBatch { get; private set; }
        public IEcsRxContentManager EcsRxContentManager { get; }
        public GameTime GameTime { get; private set; }
        
        public EcsRxGame()
        {
            _everyUpdate = new Subject<TimeSpan>();
            _everyRender = new Subject<TimeSpan>();
            _gameLoading = new Subject<Unit>();
            
            EcsRxGraphicsDeviceManager = new EcsRxGraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            EcsRxContentManager = new EcsRxContentManager(Content);
            IsMouseVisible = true;

            GameUnloading = Observable.FromEventPattern<EventArgs>(x => Exiting += x, x => Exiting -= x)
                .FirstAsync()
                .Select(x => Unit.Default);
        }

        protected override void LoadContent()
        {
            EcsRxGraphicsDevice = new EcsRxGraphicsDevice(GraphicsDevice);
            EcsRxSpriteBatch = new EcsRxSpriteBatch(GraphicsDevice);
            base.LoadContent();
            _gameLoading.OnNext(Unit.Default);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GameTime = gameTime;
            _everyRender.OnNext(gameTime.ElapsedGameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            GameTime = gameTime;
            _everyUpdate.OnNext(gameTime.ElapsedGameTime);
        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _everyUpdate.Dispose();
            _everyRender.Dispose();
            _gameLoading.Dispose();
        }

    }
}