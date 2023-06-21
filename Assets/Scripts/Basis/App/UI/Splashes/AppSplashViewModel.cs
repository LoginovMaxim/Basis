using System;
using System.Collections;
using Basis.App.UI.Splashes;
using UnityEngine;
using UnityWeld.Binding;

namespace Azur.TowerDefense.App.UI.Splashes
{
    [Binding] public sealed class AppSplashViewModel : SplashViewModel
    {
        private const float HideDelay = 0.25f;
        
        [SerializeField] private RectTransform _progressBar;
        private float _progress;
        private int _percentage;

        public override float Progress
        {
            get => _progress;
            set
            {
                if (Math.Abs(_progress - value) < Mathf.Epsilon)
                {
                    return;
                }

                _progress = Mathf.Clamp01(value);
                Percentage = (int)(_progress * 100);
                AnimateProgress();
            }
        }

        public int Percentage
        {
            get => _percentage;
            set
            {
                if (_percentage == value)
                {
                    return;
                }
                _percentage = value;
                PercentageCaption = $"{Percentage}%";
                OnPropertyChanged(nameof(PercentageCaption));
            }
        }

        [Binding] public string PercentageCaption { get; set; }

        private void AnimateProgress()
        {
            var originalOffset = _progressBar.offsetMax;
            _progressBar.anchorMax = new Vector2(_progress, _progressBar.anchorMax.y);
            _progressBar.offsetMax = originalOffset;
        }

        public override void Hide()
        {
            StartCoroutine(Hiding());
        }
        
        private IEnumerator Hiding()
        {
            yield return new WaitForSeconds(HideDelay);
            gameObject.SetActive(false);
        }
    }
}