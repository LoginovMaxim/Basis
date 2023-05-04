using App.UI.Screens.ViewModels;

namespace App.UI.Screens.Logics
{
    public abstract class BaseScreen<TScreenViewModel> : IScreen where TScreenViewModel : IScreenViewModel
    {
        protected readonly TScreenViewModel ScreenViewModel;
        private readonly int _id;
        
        protected BaseScreen(TScreenViewModel screenViewModel, int id)
        {
            ScreenViewModel = screenViewModel;
            _id = id;
        }
        
        private void SetActive(bool isActive)
        {
            ScreenViewModel.SetActive(isActive);

            if (isActive)
            {
                OnShow();
            }
            else
            {
                OnHide();
            }
        }

        protected abstract void OnShow();

        protected abstract void OnHide();

        #region IScreen

        int IScreen.Id => _id;

        void IScreen.SetActive(bool isActive)
        {
            SetActive(isActive);
        }

        void IScreen.OnShow()
        {
            OnShow();
        }

        void IScreen.OnHide()
        {
            OnHide();
        }

        #endregion
    }
}