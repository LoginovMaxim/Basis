using BasisCore.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Basis.Meta.UI
{
    public sealed class MetaSettingsPopup : WindowBase<IMetaSettingsPopupViewModel>
    {
        [SerializeField] private Button _closeButton;
        
        public override void OnShow()
        {
            base.OnShow();
            _closeButton.onClick.AddListener(() => _viewModel.Close.Execute());
        }

        public override void OnHide()
        {
            base.OnHide();
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}