using Basis.UI.Screens;
using UnityEngine;
using UnityWeld.Binding;

namespace Project.Meta.UI
{
    [Binding]
    public sealed class ButtonChangeMetaScreenViewModel : ButtonChangeScreenViewModel
    {
        [SerializeField] private MetaScreenId _metaScreenId;
        
        protected override int ScreenId => (int) _metaScreenId;
    }
}