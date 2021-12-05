namespace ViewModels.Screens
{
    public class MainScreen : IScreen
    {
        public ScreenName ScreenName => ScreenName.Main;

        public ScreenViewModel ViewModel => _viewModel;
        private MainScreenViewModel _viewModel;

        public MainScreen(MainScreenViewModel.Factory metaMainScreenViewModelFactory)
        {
            _viewModel = metaMainScreenViewModelFactory.Create();
        }
    }
}