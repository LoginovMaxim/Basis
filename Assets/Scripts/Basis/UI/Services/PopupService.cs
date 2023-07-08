using System.Collections.Generic;
using Basis.UI.Popups;
using Basis.UI.Popups.Logics;

namespace Basis.UI.Services
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