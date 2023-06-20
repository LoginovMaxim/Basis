using Basis.App.UI.Screens.Logics;

namespace Basis.App.UI.Services
{
    public interface IScreenService
    {
        IScreen CurrentScreen { get; }
        void OnChangeScreenButtonClicked(int screenId);
    }
}