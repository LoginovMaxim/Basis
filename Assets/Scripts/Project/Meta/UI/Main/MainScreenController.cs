using System;
using BasisCore.Runtime.UI.Screens;
using Project.App.Signals;
using Zenject;

namespace Project.Meta.UI.Main
{
    public sealed class MainScreenController : BaseScreenController<MainScreenModel, MainScreenView>, IMainScreenController, IDisposable
    {
        private readonly SignalBus _signalBus;
        
        public MainScreenController(
            SignalBus signalBus,
            MainScreenModel screenModel, 
            MainScreenView screenView, 
            IScreenAnimationService screenAnimationService) : 
            base(screenModel, screenView, screenAnimationService)
        {
            _signalBus = signalBus;
            var binder = new MainScreenBinder(screenModel, screenView);
            
            _screenModel.PlayCommand.Subscribe(HandlePlayMatch);
        }
        
        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }

        private void HandlePlayMatch()
        {
            _signalBus.Fire<PlayMatchSignal>();
        }

        public void Dispose()
        {
            _screenModel.PlayCommand.Unsubscribe(HandlePlayMatch);
        }
    }
}