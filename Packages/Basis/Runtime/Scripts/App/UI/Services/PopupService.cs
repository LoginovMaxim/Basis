﻿using System.Collections.Generic;
using App.UI.Popups;
using App.UI.Popups.Logics;

namespace App.UI.Services
{
    public sealed class PopupService : IPopupService
    {
        private readonly List<IPopup> _popups;

        public PopupService(List<IPopup> popups)
        {
            _popups = popups;
        }
        
        private void ShowPopup(IconPopupData iconPopupData)
        {
            _popups.ForEach(popup =>
            {
                if (popup is IIconPopup iconPopup)
                {
                    iconPopup.Spawn(iconPopupData);
                }
            });
        }
        
        #region IPopupService
        
        bool IPopupService.IsSomePopupShowing => _popups.Find(p => p.Spawned) != null;

        void IPopupService.ShowPopup(IconPopupData iconPopupData)
        {
            ShowPopup(iconPopupData);
        }
        
        #endregion
    }
}