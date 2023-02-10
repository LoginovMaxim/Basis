using System.Collections.Generic;
using System.Linq;
using App.Localizations;
using UnityWeld.Binding;
using Zenject;

namespace App.UI.Screens.ViewModels
{
    [Binding] public abstract class ScreenViewModel : MonoViewModel, IScreenViewModel
    {
        [Inject] protected SignalBus SignalBus;
        
        private List<ButtonChangeScreenMonoViewModel> _buttonViewModels;
        
        protected virtual void Start()
        {
            _buttonViewModels = GetComponentsInChildren<ButtonChangeScreenMonoViewModel>().ToList();
            _buttonViewModels.ForEach(button => button.InjectSignalBus(SignalBus));
        }
    }
}