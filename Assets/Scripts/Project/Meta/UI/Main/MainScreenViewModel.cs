using System;
using Basis.UI.Screens;
using UnityWeld.Binding;

namespace Project.Meta.UI.Main
{
    [Binding]
    public sealed class MainScreenViewModel : ScreenViewModel
    {
        public event Action OnPlayMatchButtonClicked;
        
        [Binding]
        public void HandlePlayMatch()
        {
            OnPlayMatchButtonClicked?.Invoke();
        }
    }
}