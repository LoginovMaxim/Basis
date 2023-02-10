namespace App.UI.Screens.Logics
{
    public interface IScreen
    {
        int Id { get; }
        void SetActive(bool isActive);
        string GetName();
        void Update();
    }
}