using System.Collections.Generic;
using System.Linq;
using UnityWeld.Binding;
using Zenject;

namespace Basis.App.UI.Screens.ViewModels
{
    [Binding] public abstract class ScreenViewModel : MonoViewModel, IScreenViewModel
    {
        [Inject] protected SignalBus _signalBus;
        
        private List<ButtonChangeScreenViewModel> _buttonViewModels;
        
        protected virtual void Start()
        {
            _buttonViewModels = GetComponentsInChildren<ButtonChangeScreenViewModel>().ToList();
            _buttonViewModels.ForEach(button => button.InjectSignalBus(_signalBus));
        }
    }
}