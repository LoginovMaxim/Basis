using System.Collections.Generic;
using Basis.App.UI.Popups;
using Basis.App.UI.Popups.Logics;

namespace Basis.App.UI.Services
{
    public sealed class PopupService : IPopupService
    {
        public bool IsSomePopupShowing => _popups.Find(p => p.Spawned) != null;
        
        private readonly List<IPopup> _popups;

        public PopupService(List<IPopup> popups)
        {
            _popups = popups;
        }
        
        public void ShowPopup(IconPopupData iconPopupData)
        {
            _popups.ForEach(popup =>
            {
                if (popup is IIconPopup iconPopup)
                {
                    iconPopup.Spawn(iconPopupData);
                }
            });
        }
    }
}