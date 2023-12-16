using BasisCore.Runtime.UI.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Meta.UI.Main
{
    public sealed class MainScreenView : BaseScreenView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _shopButton;

        public Button PlayButton => _playButton;
        public Button ShopButton => _shopButton;
    }
}