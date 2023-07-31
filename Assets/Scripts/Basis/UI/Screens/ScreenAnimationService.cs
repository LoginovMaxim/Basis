using System;
using System.Collections.Generic;
using Basis.UI.Screens.Animations.Hiding;
using Basis.UI.Screens.Animations.Showing;
using Basis.Utils;

namespace Basis.UI.Screens
{
    public sealed class ScreenAnimationService : IScreenAnimationService
    {
        private Dictionary<ScreenShowingType, IShowingScreenAnimator> _showingAnimatorsByShowingTypes;
        private Dictionary<ScreenHidingType, IHidingScreenAnimator> _hidingAnimatorsByShowingTypes;

        public ScreenAnimationService(
            List<IShowingScreenAnimator> showingScreenAnimators, 
            List<IHidingScreenAnimator> hidingScreenAnimators)
        {
            _showingAnimatorsByShowingTypes = new Dictionary<ScreenShowingType, IShowingScreenAnimator>();
            foreach (var showingScreenAnimator in showingScreenAnimators)
            {
                _showingAnimatorsByShowingTypes.Add(showingScreenAnimator.ScreenShowingType, showingScreenAnimator);
            }

            _hidingAnimatorsByShowingTypes = new Dictionary<ScreenHidingType, IHidingScreenAnimator>();
            foreach (var hidingScreenAnimator in hidingScreenAnimators)
            {
                _hidingAnimatorsByShowingTypes.Add(hidingScreenAnimator.ScreenHidingType, hidingScreenAnimator);
            }
        }

        public void ShowingScreen(IScreenViewModel screenViewModel, ScreenShowingType screenShowingType)
        {
            if (!_showingAnimatorsByShowingTypes.ContainsKey(screenShowingType))
            {
                throw new Exception($"Missing ScreenAnimator for {screenShowingType} animation type"
                    .WithColor(LoggerColor.Red));
            }
            
            _showingAnimatorsByShowingTypes[screenShowingType].Play(screenViewModel);
        }

        public void HidingScreen(IScreenViewModel screenViewModel, ScreenHidingType screenHidingType)
        {
            if (!_hidingAnimatorsByShowingTypes.ContainsKey(screenHidingType))
            {
                throw new Exception($"Missing ScreenAnimator for {screenHidingType} animation type"
                    .WithColor(LoggerColor.Red));
            }
            
            _hidingAnimatorsByShowingTypes[screenHidingType].Play(screenViewModel);
        }
    }
}