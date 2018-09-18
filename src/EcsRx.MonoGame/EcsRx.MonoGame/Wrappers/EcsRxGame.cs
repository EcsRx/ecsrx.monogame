using System;
using EcsRx.MicroRx.Subjects;
using EcsRx.MonoGame.Wrappers;
using Microsoft.Xna.Framework;
using IGraphicsDeviceManager = Microsoft.Xna.Framework.IGraphicsDeviceManager;

namespace EcsRx.MonoGame
{
    public class EcsRxGame : Game, IGame
    {
        private readonly Subject<GameTime> _everyUpdate, _everyRender;
        private readonly Subject<bool> _gameUnloading, _gameLoading;

        public IObservable<GameTime> EveryUpdate => _everyUpdate;
        public IObservable<GameTime> EveryRender => _everyRender;
        public IObservable<bool> GameLoading => _gameLoading;
        public IObservable<bool> GameUnloading => _gameUnloading;
        
        public IGraphicsDeviceManager GraphicsDeviceManager { get; }
        public ISpriteBatch SpriteBatch { get; private set; }
        public IContentManager ContentManager { get; }
        
        public EcsRxGame()
        {
            _everyUpdate = new Subject<GameTime>();
            _everyRender = new Subject<GameTime>();
            _gameLoading = new Subject<bool>();
            _gameUnloading = new Subject<bool>();
            
            GraphicsDeviceManager = new EcsRxGraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ContentManager = new EcsRxContentManager(Content);
        }

        protected override void LoadContent()
        {
            SpriteBatch = new EcsRxSpriteBatch(GraphicsDevice);
            base.LoadContent();
            _gameLoading.OnNext(true);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            _gameLoading.OnNext(false);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _everyRender.OnNext(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _everyUpdate.OnNext(gameTime);
        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _everyUpdate.Dispose();
            _everyRender.Dispose();
            _gameLoading.Dispose();
            _gameUnloading.Dispose();
        }

    }
}