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

        public string GetName()
        {
            return ScreenViewModel.ToString();
        }

        protected virtual void Update()
        {
        }
        
        private void SetActive(bool isActive)
        {
            ScreenViewModel.SetActive(isActive);

            if (!isActive)
            {
                return;
            }
            
            Update();
        }
        
        #region IScreen

        int IScreen.Id => _id;

        void IScreen.SetActive(bool isActive)
        {
            SetActive(isActive);
        }

        void IScreen.Update()
        {
            Update();
        }

        #endregion
    }
}