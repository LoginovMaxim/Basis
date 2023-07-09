namespace Basis.UI.Screens
{
    public interface IScreenService
    {
        IScreen CurrentScreen { get; }
        void OnChangeScreenButtonClicked(int screenId);
    }
}