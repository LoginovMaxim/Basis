namespace ViewModels.Screens
{
    public interface IScreen
    {
        ScreenName ScreenName { get; }
        ScreenViewModel ViewModel { get; }
    }
}