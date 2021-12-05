using System;
using System.Collections.Generic;
using System.Linq;
using Localizations;
using UnityWeld.Binding;

namespace ViewModels.Screens
{
    [Binding]
    public abstract class ScreenViewModel : LocalizableViewModel
    {
        public event Action<ScreenName> ChangeScreenButtonClicked;

        private List<ButtonChangeScreenViewModel> _buttonViewModels;

        private void Awake()
        {
            _buttonViewModels = GetComponentsInChildren<ButtonChangeScreenViewModel>().ToList();
            _buttonViewModels?.ForEach(button => button.ChangeScreenButtonClicked += OnChangeScreenButtonClicked);
        }

        private void OnChangeScreenButtonClicked(ScreenName screenName)
        {
            ChangeScreenButtonClicked?.Invoke(screenName);
        }

        private void OnDestroy()
        {
            _buttonViewModels?.ForEach(button => button.ChangeScreenButtonClicked -= OnChangeScreenButtonClicked);
        }
    }
}