using System;
using System.Collections.Generic;
using System.Linq;
using Basis.Signals;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

namespace Basis.UI.Screens
{
    [Binding] 
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class ScreenViewModel : MonoViewModel, IScreenViewModel
    {
        [Inject] protected SignalBus _signalBus;
        
        private List<ButtonChangeScreenViewModel> _buttonViewModels;

        public RectTransform RectTransform { get; private set; }
        public CanvasGroup CanvasGroup { get; private set; }

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
            CanvasGroup = GetComponent<CanvasGroup>();
        }

        protected virtual void Start()
        {
            _buttonViewModels = GetComponentsInChildren<ButtonChangeScreenViewModel>().ToList();
            _buttonViewModels.ForEach(button => button.OnChanceScreenButtonClicked += HandleChangeScreen);
        }

        protected void OnDestroy()
        {
            _buttonViewModels.ForEach(button => button.OnChanceScreenButtonClicked -= HandleChangeScreen);
        }

        private void HandleChangeScreen(int screenId)
        {
            _signalBus.Fire(new SwitchScreenSignal(screenId));
        }
    }
}