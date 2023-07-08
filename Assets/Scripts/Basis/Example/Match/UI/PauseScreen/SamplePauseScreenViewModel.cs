using Basis.App.UI.Screens.ViewModels;
using Basis.Example.Match.Signals;
using UnityWeld.Binding;

namespace Basis.Example.Match.UI.PauseScreen
{
    [Binding] public sealed class SamplePauseScreenViewModel : ScreenViewModel
    {
        [Binding] public void OnUnpauseButtonClicked()
        {
            _signalBus.Fire<UnpauseMatchSampleSignal>();
        }
    }
}