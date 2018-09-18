﻿using System;
using System.Reactive;
using System.Reactive.Linq;
using EcsRx.MicroRx.Subjects;
using EcsRx.MonoGame.Wrappers;
using Microsoft.Xna.Framework;

namespace EcsRx.MonoGame
{
    public class EcsRxEcsRxGame : Game, IEcsRxGame
    {
        private readonly Subject<GameTime> _everyUpdate, _everyRender;
        private readonly Subject<Unit> _gameLoading;

        public IObservable<GameTime> EveryUpdate => _everyUpdate;
        public IObservable<GameTime> EveryRender => _everyRender;
        public IObservable<Unit> GameLoading => _gameLoading;
        public IObservable<Unit> GameUnloading { get; protected set; }
        
        public IEcsRxGraphicsDeviceManager EcsRxGraphicsDeviceManager { get; }
        public IEcsRxGraphicsDevice EcsRxGraphicsDevice { get; private set; }
        public IEcsRxSpriteBatch EcsRxSpriteBatch { get; private set; }
        public IEcsRxContentManager EcsRxContentManager { get; }
        public GameTime GameTime { get; private set; }
        
        public EcsRxEcsRxGame()
        {
            _everyUpdate = new Subject<GameTime>();
            _everyRender = new Subject<GameTime>();
            _gameLoading = new Subject<Unit>();
            
            EcsRxGraphicsDeviceManager = new EcsRxEcsRxGraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            EcsRxContentManager = new EcsRxEcsRxContentManager(Content);
            IsMouseVisible = true;

            GameUnloading = Observable.FromEventPattern<EventArgs>(x => Exiting += x, x => Exiting -= x)
                .FirstAsync()
                .Select(x => Unit.Default);
        }

        protected override void LoadContent()
        {
            EcsRxGraphicsDevice = new EcsRxGraphicsDevice(GraphicsDevice);
            EcsRxSpriteBatch = new EcsRxEcsRxSpriteBatch(GraphicsDevice);
            base.LoadContent();
            _gameLoading.OnNext(Unit.Default);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GameTime = gameTime;
            _everyRender.OnNext(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            GameTime = gameTime;
            _everyUpdate.OnNext(gameTime);
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