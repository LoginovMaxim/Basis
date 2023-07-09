namespace Basis.UI.Screens
{
    public abstract class BaseScreen<TScreenViewModel> : IScreen where TScreenViewModel : IScreenViewModel
    {
        protected readonly TScreenViewModel ScreenViewModel;
        public int Id { get; private set; }
        
        protected BaseScreen(TScreenViewModel screenViewModel, int id)
        {
            ScreenViewModel = screenViewModel;
            Id = id;
        }
        
        public void SetActive(bool isActive)
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

        public abstract void OnShow();

        public abstract void OnHide();
    }
}