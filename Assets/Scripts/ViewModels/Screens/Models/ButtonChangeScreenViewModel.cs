using System;
using UnityEngine;
using UnityWeld.Binding;

namespace ViewModels.Screens
{
    [Binding]
    public class ButtonChangeScreenViewModel : ViewModel
    {
        public event Action<ScreenName> ChangeScreenButtonClicked;

        [SerializeField] private ScreenName _screenName;

        [Binding]
        public void OnChangeScreenButtonClicked()
        {
            ChangeScreenButtonClicked?.Invoke(_screenName);
        }
    }
}