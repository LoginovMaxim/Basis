using App.UI.Screens.ViewModels;
using UnityEngine;
using UnityWeld.Binding;

namespace Example.Match.UI
{
    [Binding] public sealed class ButtonChangeMatchScreenViewModel : ButtonChangeScreenViewModel
    {
        [SerializeField] private SampleMatchScreenId sampleMatchScreenId;
        
        protected override int ScreenId => (int) sampleMatchScreenId;
    }
}