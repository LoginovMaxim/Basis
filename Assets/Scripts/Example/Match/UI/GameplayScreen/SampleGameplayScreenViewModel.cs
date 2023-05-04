using App.UI.Screens.ViewModels;
using Example.Match.Signals;
using UnityWeld.Binding;

namespace Example.Match.UI.GameplayScreen
{
    [Binding] public sealed class SampleGameplayScreenViewModel : ScreenViewModel
    {
        [Binding] public void OnPauseButtonClicked()
        {
            SignalBus.Fire<PauseMatchSampleSignal>();
        }
    }
}