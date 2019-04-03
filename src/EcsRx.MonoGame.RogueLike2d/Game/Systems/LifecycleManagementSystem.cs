using System;
using System.Collections.Generic;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Groups.Observable;
using EcsRx.MonoGame.Wrappers;
using EcsRx.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EcsRx.MonoGame.RogueLike2d.Game.Systems
{
    public class LifecycleManagementSystem : IManualSystem
    {
        public IGroup Group { get; } = new EmptyGroup();

        private readonly IEcsRxGame _ecsRxGame;
        private readonly List<IDisposable> _subscriptions = new List<IDisposable>();

        public LifecycleManagementSystem(IEcsRxGame ecsRxGame)
        { _ecsRxGame = ecsRxGame; }

        private void CheckIfGameShouldQuit(TimeSpan elapsedTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            { _ecsRxGame.Exit(); }
        }

        private void ClearScreen(TimeSpan elapsedTime)
        { _ecsRxGame.EcsRxGraphicsDevice.Clear(Color.CornflowerBlue); }

        public void StartSystem(IObservableGroup observableGroup)
        {
            var quitSubscriptions = _ecsRxGame.OnUpdate.Subscribe(CheckIfGameShouldQuit);
            var clearSubscriptions = _ecsRxGame.OnRender.Subscribe(ClearScreen);
            _subscriptions.Add(quitSubscriptions);
            _subscriptions.Add(clearSubscriptions);
        }

        public void StopSystem(IObservableGroup observableGroup)
        {
            _subscriptions.DisposeAll();
            _subscriptions.Clear();
        }
    }
}