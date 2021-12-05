using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monos;
using ViewModels.Screens;

namespace Services
{
    public class MetaScreensService : Service
    {
        private readonly MainScreen _mainScreen;
        private readonly ShopScreen _shopScreen;

        private IScreen _currentScreen;

        private List<IScreen> _screens;
        
        public MetaScreensService(
            MainScreen mainScreen,
            ShopScreen shopScreen,
            MonoUpdater monoUpdater) : base(monoUpdater)
        {
            _mainScreen = mainScreen;
            _shopScreen = shopScreen;

            InitializeScreens();
        }

        public override Task Launch()
        {
            _mainScreen.ViewModel.SetActive(true);
            _currentScreen = _mainScreen;
            
            return Task.CompletedTask;
        }

        private void InitializeScreens()
        {
            _screens = new List<IScreen>()
            {
                _mainScreen,
                _shopScreen
            };
            
            _screens.ForEach(screen =>
            {
                screen.ViewModel.ChangeScreenButtonClicked += OnChangeScreenButtonClicked;
            });
        }

        private void OnChangeScreenButtonClicked(ScreenName screenName)
        {
            var screen = _screens.FirstOrDefault(screen => screen.ScreenName == screenName);
            
            if (screen == null)
                return;
            
            _currentScreen.ViewModel.SetActive(false);
            _currentScreen = screen;
            _currentScreen.ViewModel.SetActive(true);
        }

        protected override void ProcessRun() {}

        public override void Dispose()
        {
            base.Dispose();
            _screens.ForEach(screen =>
            {
                screen.ViewModel.ChangeScreenButtonClicked -= OnChangeScreenButtonClicked;
            });
        }
    }
}