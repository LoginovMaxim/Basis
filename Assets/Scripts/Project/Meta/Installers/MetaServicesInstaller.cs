using Project.Meta.Services.Chat;
using Zenject;

namespace Project.Meta.Installers
{
    public sealed class MetaServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AuthService>().AsSingle().NonLazy();
        }
    }
}