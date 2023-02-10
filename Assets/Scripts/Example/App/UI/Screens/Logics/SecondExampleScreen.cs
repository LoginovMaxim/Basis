using App.UI.Screens.Logics;
using Example.App.UI.Screens.ViewModels;

namespace Example.App.UI.Screens.Logics
{
    public class SecondExampleScreen : BaseScreen<ISecondExampleScreenViewModel>, ISecondExampleScreen
    {
        public SecondExampleScreen(ISecondExampleScreenViewModel screenViewModel, int id) : base(screenViewModel, id)
        {
        }
    }
}