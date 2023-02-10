using App.UI.Services;

namespace Example.App.UI.Screens
{
    public interface IExampleScreenService : IScreenService
    {
        void ChangeScreen(ExampleScreenId exampleScreenId);
    }
}