using App.UI.Screens.Logics;
using Example.App.UI.Screens.ViewModels;

namespace Example.App.UI.Screens.Logics
{
    public sealed class FirstExampleScreen : BaseScreen<IFirstExampleScreenViewModel>, IFirstExampleScreen
    {
        public FirstExampleScreen(IFirstExampleScreenViewModel screenViewModel, int id) : base(screenViewModel, id)
        {
        }
    }
}