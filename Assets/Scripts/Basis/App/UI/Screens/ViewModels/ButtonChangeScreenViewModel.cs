using Basis.App.UI.Signals;
using UnityWeld.Binding;
using Zenject;

namespace Basis.App.UI.Screens.ViewModels
{
    [Binding] public abstract class ButtonChangeScreenViewModel : MonoViewModel
    {
        protected abstract int ScreenId { get; }
        
        private SignalBus _signalBus;
        
        [Binding] public void OnChangeScreenButtonClicked()
        {
            _signalBus.Fire(new SwitchScreenSignal(ScreenId));
        }

        public void InjectSignalBus(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
    }
}