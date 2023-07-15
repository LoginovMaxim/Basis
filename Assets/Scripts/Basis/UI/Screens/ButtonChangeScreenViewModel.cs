using System;
using UnityWeld.Binding;

namespace Basis.UI.Screens
{
    [Binding] public abstract class ButtonChangeScreenViewModel : MonoViewModel
    {
        public event Action<int> OnChanceScreenButtonClicked;
        protected abstract int ScreenId { get; }
        
        [Binding] public void OnChangeScreenButtonClicked()
        {
            OnChanceScreenButtonClicked?.Invoke(ScreenId);
        }
    }
}