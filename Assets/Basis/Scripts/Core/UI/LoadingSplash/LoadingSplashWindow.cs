using BasisCore.UI;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Basis.Core.UI
{
    public sealed class LoadingSplashWindow : WindowBase<ILoadingSplashWindowViewModel>
    {
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private TextMeshProUGUI _progressText;
        
        public override void OnShow()
        {
            base.OnShow();
            
            _viewModel.Progress.Subscribe(HandleProgressChanged).AddTo(_subscribes);
        }

        private void HandleProgressChanged(float progress)
        {
            _progressSlider.value = progress;
            _progressText.text = $"{(100 * progress)}%";
        }
    }
}