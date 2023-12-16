using System;
using BasisCore.Runtime.UI.Screens;
using Project.App.Signals;
using Zenject;

namespace Project.Match.UI.Gameplay
{
    public sealed class GameplayScreenController : BaseScreenController<GameplayScreenModel, GameplayScreenView>, IGameplayScreenController, IDisposable
    {
        private readonly SignalBus _signalBus;
        
        public GameplayScreenController(
            SignalBus signalBus,
            GameplayScreenModel screenModel, 
            GameplayScreenView screenView, 
            IScreenAnimationService screenAnimationService) : 
            base(screenModel, screenView, screenAnimationService)
        {
            _signalBus = signalBus;
            var binder = new GameplayScreenBinder(screenModel, screenView);
            
            _screenModel.QuitCommand.Subscribe(HandleQuitMatch);
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }
        
        private void HandleQuitMatch()
        {
            _signalBus.Fire<QuitMatchSignal>();
        }

        public void Dispose()
        {
            _screenModel.QuitCommand.Unsubscribe(HandleQuitMatch);
        }
    }
}