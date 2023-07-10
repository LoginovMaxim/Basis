using Basis.UI.Screens.Animations.Showing;

namespace Basis.UI.Screens
{
    public abstract class BaseScreen<TScreenViewModel> : IScreen where TScreenViewModel : IScreenViewModel
    {
        private IShowingScreenAnimator _showingShowingScreenAnimator;
        private IShowingScreenAnimator _hidingShowingScreenAnimator;

        private readonly IScreenAnimationService _screenAnimationService;
        protected readonly TScreenViewModel _screenViewModel;
        
        protected ScreenShowingType _screenShowingType { get; private set; }
        protected ScreenHidingType _screenHidingType { get; private set; }
        protected int _id { get; private set; }

        public int Id => _id;
        
        protected BaseScreen(IScreenAnimationService screenAnimationService, TScreenViewModel screenViewModel)
        {
            _screenAnimationService = screenAnimationService;
            _screenViewModel = screenViewModel;
        }

        public void Init(int id, ScreenShowingType screenShowingType, ScreenHidingType screenHidingType)
        {
            _id = id;
            _screenShowingType = screenShowingType;
            _screenHidingType = screenHidingType;
        }

        public void Show()
        {
            OnShow();
            _screenAnimationService.ShowingScreen(_screenViewModel, _screenShowingType);
        }

        public void Hide()
        {
            OnHide();
            _screenAnimationService.HidingScreen(_screenViewModel, _screenHidingType);
        }

        protected abstract void OnShow();

        protected abstract void OnHide();
    }
}