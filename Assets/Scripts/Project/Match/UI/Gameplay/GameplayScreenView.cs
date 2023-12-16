using BasisCore.Runtime.UI.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Match.UI.Gameplay
{
    public sealed class GameplayScreenView : BaseScreenView
    {
        [SerializeField] private Button _quitButton;

        public Button QuitButton => _quitButton;
    }
}