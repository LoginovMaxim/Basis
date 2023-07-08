using Basis.UI.Screens.Logics;

namespace Basis.UI.Services
{
    public interface IScreenService
    {
        IScreen CurrentScreen { get; }
        void OnChangeScreenButtonClicked(int screenId);
    }
}