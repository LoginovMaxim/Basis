namespace ViewModels.Screens
{
    public class ShopScreen : IScreen
    {
        public ScreenName ScreenName => ScreenName.Shop;

        public ScreenViewModel ViewModel => _viewModel;
        private ShopScreenViewModel _viewModel;

        public ShopScreen(ShopScreenViewModel.Factory shopScreenViewModelFactory)
        {
            _viewModel = shopScreenViewModelFactory.Create();
        }
    }
}