using BasisCore.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Basis.Meta.UI
{
    public sealed class MetaMainWindow : WindowBase<IMetaMainWindowViewModel>
    {
        [SerializeField] private Button _settingsButton;
        
        public override void OnShow()
        {
            base.OnShow();
            _settingsButton.onClick.AddListener(() => _viewModel.OpenSettings.Execute());
        }

        public override void OnHide()
        {
            base.OnHide();
            _settingsButton.onClick.RemoveAllListeners();
        }
    }
}