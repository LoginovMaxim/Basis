using System;
using UnityEngine;
using UnityWeld.Binding;

namespace Basis.UI.Splashes
{
    [Binding] public sealed class LoadingSplashViewModel : BaseLoadingSplashViewModel
    {
        [SerializeField] private float _smooth;
        
        private float _progress;
        private float _smoothProgress;
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

        [Binding]
        public float SmoothProgress
        {
            get => _smoothProgress;
            set
            {
                if (Math.Abs(_smoothProgress - value) < Mathf.Epsilon)
                {
                    return;
                }

                _smoothProgress = Mathf.Clamp01(value);
                OnPropertyChanged(nameof(SmoothProgress));
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

        private void Update()
        {
            SmoothProgress = Mathf.Lerp(SmoothProgress, _progress, _smooth * Time.deltaTime);
        }

        public void Show()
        {
            SmoothProgress = 0;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}