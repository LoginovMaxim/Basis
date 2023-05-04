using App.UI.Screens.ViewModels;
using Example.Match.Signals;
using UnityWeld.Binding;

namespace Example.Match.UI.PauseScreen
{
    [Binding] public sealed class SamplePauseScreenViewModel : ScreenViewModel
    {
        [Binding] public void OnUnpauseButtonClicked()
        {
            SignalBus.Fire<UnpauseMatchSampleSignal>();
        }
    }
}