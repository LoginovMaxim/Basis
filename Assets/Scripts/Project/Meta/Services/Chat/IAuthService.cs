using Project.Meta.UI.Auth;

namespace Project.Meta.Services.Chat
{
    public interface IAuthService
    {
        public void Auth(AuthData authData);
    }
}