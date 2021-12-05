using UnityWeld.Binding;
using Zenject;

namespace ViewModels.Screens
{
    [Binding]
    public class MainScreenViewModel : ScreenViewModel
    {
        public class Factory : PlaceholderFactory<MainScreenViewModel>
        {
        }
    }
}