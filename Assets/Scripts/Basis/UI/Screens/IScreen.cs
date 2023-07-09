namespace Basis.UI.Screens
{
    public interface IScreen
    {
        int Id { get; }
        void SetActive(bool isActive);
        void OnShow();
        void OnHide();
    }
}