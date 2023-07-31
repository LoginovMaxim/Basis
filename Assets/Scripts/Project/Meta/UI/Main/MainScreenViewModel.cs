using Basis.UI.Screens;
using Project.App.Signals;
using UnityWeld.Binding;

namespace Project.Meta.UI.Main
{
    [Binding]
    public sealed class MainScreenViewModel : ScreenViewModel
    {
        [Binding]
        public void HandlePlayMatch()
        {
            _signalBus.Fire<PlayMatchSignal>();
        }
    }
}