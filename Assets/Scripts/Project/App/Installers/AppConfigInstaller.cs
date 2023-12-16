using BasisCore.Runtime.Configs.BinaryConfigs;
using BasisCore.Runtime.Configs.UI;
using BasisCore.Runtime.ResourceProviders;
using Zenject;
using ResourceProvider = BasisCore.Runtime.ResourceProviders.ResourceProvider;

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