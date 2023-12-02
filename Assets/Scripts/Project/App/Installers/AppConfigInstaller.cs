using Basis.Configs;
using Basis.Configs.BinaryConfigs;
using Basis.Configs.UI;
using Basis.ResourceProviders;
using Zenject;
using ResourceProvider = Basis.ResourceProviders.ResourceProvider;

namespace Project.App.Installers
{
    public sealed class AppConfigInstaller : MonoInstaller
    {
        public ScreenAnimationConfig ScreenAnimationConfig;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ScreenAnimationConfig>().FromScriptableObject(ScreenAnimationConfig).AsSingle().NonLazy();
            Container.BindInterfacesTo<AddressableResourceProvider>().AsSingle().NonLazy();
            Container.BindInterfacesTo<BinaryConfigManager>().AsSingle().NonLazy();
        }
    }
}