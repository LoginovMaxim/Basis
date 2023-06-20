namespace Basis.App.UI.Screens.Logics
{
    public interface IScreen
    {
        int Id { get; }
        void SetActive(bool isActive);
        void OnShow();
        void OnHide();
    }
}