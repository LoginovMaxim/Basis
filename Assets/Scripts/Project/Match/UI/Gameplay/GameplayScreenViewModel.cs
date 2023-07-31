using Basis.UI.Screens;
using Project.App.Signals;
using UnityWeld.Binding;

namespace Project.Match.UI.Gameplay
{
    [Binding]
    public sealed class GameplayScreenViewModel : ScreenViewModel
    {
        [Binding]
        public void HandleQuitMatch()
        {
            _signalBus.Fire<QuitMatchSignal>();
        }
    }
}