using System;
using System.Collections;
using UnityEngine;
using UnityWeld.Binding;

namespace Basis.UI.Splashes
{
    [Binding] public sealed class AppSplashViewModel : SplashViewModel
    {
        private const float HideDelay = 0.25f;
        
        private float _progress;
        private int _percentage;

        [Binding]
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
                OnPropertyChanged(nameof(Progress));
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

        public override void Show()
        {
            gameObject.SetActive(true);
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