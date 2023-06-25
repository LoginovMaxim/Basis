using Basis.App.UI.Screens.ViewModels;
using Basis.Example.Meta.Signals;
using UnityWeld.Binding;

namespace Basis.Example.Meta.UI.MainScreen
{
    [Binding] public sealed class SampleMainScreenViewModel : ScreenViewModel
    {
        [Binding] public void OnPlayButtonClicked()
        {
            SignalBus.Fire<PlayMatchSampleSignal>();
        }
    }
}