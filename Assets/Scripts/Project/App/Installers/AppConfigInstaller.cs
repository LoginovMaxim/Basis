using Basis.Configs;
using Zenject;
using ResourceProvider = Basis.Configs.ResourceProvider;

namespace Basis.Installers
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