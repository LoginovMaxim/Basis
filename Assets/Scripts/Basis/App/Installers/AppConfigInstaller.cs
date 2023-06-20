using Basis.App.Configs;
using Zenject;
using ResourceProvider = Basis.App.Configs.ResourceProvider;

namespace Basis.App.Installers
{
    public sealed class AppConfigInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ResourceProvider>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<BinaryConfigManager>().AsSingle();
        }
    }
}