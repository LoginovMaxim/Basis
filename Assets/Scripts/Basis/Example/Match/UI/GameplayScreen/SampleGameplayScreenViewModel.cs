﻿using Basis.App.UI.Screens.ViewModels;
using Basis.Example.Match.Signals;
using UnityWeld.Binding;

namespace Basis.Example.Match.UI.GameplayScreen
{
    [Binding] public sealed class SampleGameplayScreenViewModel : ScreenViewModel
    {
        [Binding] public void OnPauseButtonClicked()
        {
            SignalBus.Fire<PauseMatchSampleSignal>();
        }
    }
}