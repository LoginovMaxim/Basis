using Basis.UI.Screens;
using Project.Meta.Services.Chat;

namespace Project.Meta.UI.Auth
{
    public sealed class AuthScreen : BaseScreen<AuthScreenViewModel>, IAuthScreen
    {
        private readonly IAuthService _authService;
        
        public AuthScreen(
            IAuthService authService,
            IScreenAnimationService screenAnimationService, 
            AuthScreenViewModel screenViewModel) : 
            base(screenAnimationService, screenViewModel)
        {
            _authService = authService;
        }

        protected override void OnShow()
        {
            _screenViewModel.OnAuthRequested += HandleSenMessageRequested;
        }

        protected override void OnHide()
        {
            _screenViewModel.OnAuthRequested -= HandleSenMessageRequested;
        }

        private void HandleSenMessageRequested(AuthData authData)
        {
            _authService.Auth(authData);
        }
    }
}