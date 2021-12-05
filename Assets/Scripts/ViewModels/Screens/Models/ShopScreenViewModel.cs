using UnityWeld.Binding;
using Zenject;

namespace ViewModels.Screens
{
    [Binding]
    public class ShopScreenViewModel : ScreenViewModel
    {
        public class Factory : PlaceholderFactory<ShopScreenViewModel>
        {
        }
    }
}