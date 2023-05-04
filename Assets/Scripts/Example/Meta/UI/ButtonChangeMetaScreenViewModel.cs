using App.UI.Screens.ViewModels;
using UnityEngine;
using UnityWeld.Binding;

namespace Example.Meta.UI
{
    [Binding] public sealed class ButtonChangeMetaScreenViewModel : ButtonChangeScreenViewModel
    {
        [SerializeField] private SampleMetaScreenId _sampleMetaScreenId;
        
        protected override int ScreenId => (int) _sampleMetaScreenId;
    }
}