using Basis.App.UI.Popups;

namespace Basis.App.UI.Services
{
    public interface IPopupService
    {
        bool IsSomePopupShowing { get; }
        
        void ShowPopup(IconPopupData iconPopupData);
    }
}