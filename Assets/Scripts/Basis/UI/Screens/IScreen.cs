namespace Basis.UI.Screens
{
    public interface IScreen
    {
        public int Id { get; }
        public void Init(int id, ScreenShowingType screenShowingType, ScreenHidingType screenHidingType);
        public void Show();
        public void Hide();
    }
}