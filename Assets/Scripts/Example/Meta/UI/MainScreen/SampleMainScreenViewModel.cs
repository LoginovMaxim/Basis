using App.UI.Screens.ViewModels;
using Example.Meta.Signals;
using UnityWeld.Binding;

namespace Example.Meta.UI.MainScreen
{
    [Binding] public sealed class SampleMainScreenViewModel : ScreenViewModel
    {
        [Binding] public void OnPlayButtonClicked()
        {
            SignalBus.Fire<PlayMatchSampleSignal>();
        }
    }
}