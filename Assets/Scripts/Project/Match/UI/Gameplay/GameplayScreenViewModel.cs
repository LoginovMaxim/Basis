using System;
using Basis.UI.Screens;
using UnityWeld.Binding;

namespace Project.Match.UI.Gameplay
{
    [Binding]
    public sealed class GameplayScreenViewModel : ScreenViewModel
    {
        public event Action OnQuitMatchButtonClicked;
        
        [Binding]
        public void HandleQuitMatch()
        {
            OnQuitMatchButtonClicked?.Invoke();
        }
    }
}