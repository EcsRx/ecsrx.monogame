using System;
using System.Collections.Generic;
using SystemsRx.Extensions;
using SystemsRx.Scheduling;
using SystemsRx.Systems.Conventional;
using EcsRx.MonoGame.Wrappers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EcsRx.MonoGame.RogueLike2d.Game.Systems
{
    public class LifecycleManagementSystem : IManualSystem
    {
        private readonly IEcsRxGame _ecsRxGame;
        private readonly List<IDisposable> _subscriptions = new List<IDisposable>();

        public LifecycleManagementSystem(IEcsRxGame ecsRxGame)
        { _ecsRxGame = ecsRxGame; }

        private void CheckIfGameShouldQuit(ElapsedTime elapsedTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            { _ecsRxGame.Exit(); }
        }

        private void ClearScreen(ElapsedTime elapsedTime)
        { _ecsRxGame.EcsRxGraphicsDevice.Clear(Color.CornflowerBlue); }

        public void StartSystem()
        {
            var quitSubscriptions = _ecsRxGame.OnUpdate.Subscribe(CheckIfGameShouldQuit);
            var clearSubscriptions = _ecsRxGame.OnPreRender.Subscribe(ClearScreen);
            _subscriptions.Add(quitSubscriptions);
            _subscriptions.Add(clearSubscriptions);
        }

        public void StopSystem()
        {
            _subscriptions.DisposeAll();
            _subscriptions.Clear();
        }
    }
}