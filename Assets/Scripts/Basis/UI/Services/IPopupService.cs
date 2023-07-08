using Basis.UI.Popups;

namespace Basis.UI.Services
{
    public interface IPopupService
    {
        bool IsSomePopupShowing { get; }
        
        void ShowPopup(IconPopupData iconPopupData);
    }
}