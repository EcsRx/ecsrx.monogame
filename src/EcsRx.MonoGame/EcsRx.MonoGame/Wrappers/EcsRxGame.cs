using System;
using System.Reactive;
using System.Reactive.Linq;
using EcsRx.MicroRx.Subjects;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame.Wrappers
{
    public class EcsRxGame : Game, IEcsRxGame
    {
        private readonly Subject<TimeSpan> _onUpdate, _onRender, _onPreRender, _onPostRender;
        private readonly Subject<Unit> _gameLoading;

        public IObservable<TimeSpan> OnUpdate => _onUpdate;
        public IObservable<TimeSpan> OnRender => _onRender;
        public IObservable<TimeSpan> OnPreRender => _onPreRender;
        public IObservable<TimeSpan> OnPostRender => _onPostRender;
        public IObservable<Unit> GameLoading => _gameLoading;
        public IObservable<Unit> GameUnloading { get; }
        
        public IEcsRxGraphicsDeviceManager EcsRxGraphicsDeviceManager { get; }
        public IEcsRxGraphicsDevice EcsRxGraphicsDevice { get; private set; }
        public IEcsRxSpriteBatch EcsRxSpriteBatch { get; private set; }
        public IEcsRxContentManager EcsRxContentManager { get; }
        public GameTime GameTime { get; private set; }
        
        public EcsRxGame()
        {
            _onUpdate = new Subject<TimeSpan>();
            _onRender = new Subject<TimeSpan>();
            _onPreRender = new Subject<TimeSpan>();
            _onPostRender = new Subject<TimeSpan>();
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
            _onPreRender.OnNext(gameTime.ElapsedGameTime);
            _onRender.OnNext(gameTime.ElapsedGameTime);
            _onPostRender.OnNext(gameTime.ElapsedGameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            GameTime = gameTime;
            _onUpdate.OnNext(gameTime.ElapsedGameTime);
        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _onUpdate.Dispose();
            _onRender.Dispose();
            _gameLoading.Dispose();
        }

    }
}