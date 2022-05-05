using System;
using System.Reactive.Linq;
using SystemsRx.Scheduling;
using EcsRx.MicroRx.Subjects;
using Microsoft.Xna.Framework;
using SystemsRx.MicroRx;

namespace EcsRx.MonoGame.Wrappers
{
    public class EcsRxGame : Game, IEcsRxGame
    {
        private readonly Subject<ElapsedTime> _onPreUpdate, _onUpdate, _onPostUpdate, _onRender, _onPreRender, _onPostRender;
        private readonly Subject<Unit> _gameLoading;

        public IObservable<ElapsedTime> OnUpdate => _onUpdate;
        public IObservable<ElapsedTime> OnPreUpdate => _onPreUpdate;
        public IObservable<ElapsedTime> OnPostUpdate => _onPostUpdate;
        public IObservable<ElapsedTime> OnRender => _onRender;
        public IObservable<ElapsedTime> OnPreRender => _onPreRender;
        public IObservable<ElapsedTime> OnPostRender => _onPostRender;
        public IObservable<Unit> GameLoading => _gameLoading;
        public IObservable<Unit> GameUnloading { get; }
        
        public IEcsRxGraphicsDeviceManager EcsRxGraphicsDeviceManager { get; }
        public IEcsRxGraphicsDevice EcsRxGraphicsDevice { get; private set; }
        public IEcsRxSpriteBatch EcsRxSpriteBatch { get; private set; }
        public IEcsRxContentManager EcsRxContentManager { get; }
        public GameTime NativeGameTime { get; private set; }
        public ElapsedTime ElapsedTime { get; private set; }
        
        public EcsRxGame()
        {
            _onPreUpdate = new Subject<ElapsedTime>();
            _onUpdate = new Subject<ElapsedTime>();
            _onPostUpdate = new Subject<ElapsedTime>();
            _onRender = new Subject<ElapsedTime>();
            _onPreRender = new Subject<ElapsedTime>();
            _onPostRender = new Subject<ElapsedTime>();
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
            NativeGameTime = gameTime;
            ElapsedTime = new ElapsedTime(gameTime.ElapsedGameTime, gameTime.TotalGameTime);
            
            _onPreRender.OnNext(ElapsedTime);
            _onRender.OnNext(ElapsedTime);
            _onPostRender.OnNext(ElapsedTime);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            NativeGameTime = gameTime;
            ElapsedTime = new ElapsedTime(gameTime.ElapsedGameTime, gameTime.TotalGameTime);
            
            _onPreUpdate.OnNext(ElapsedTime);
            _onUpdate.OnNext(ElapsedTime);
            _onPostUpdate.OnNext(ElapsedTime);
        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _onPreUpdate.Dispose();
            _onUpdate.Dispose();
            _onPostUpdate.Dispose();
            _onRender.Dispose();
            _onPreRender.Dispose();
            _onPostRender.Dispose();
            _gameLoading.Dispose();
        }
    }
}