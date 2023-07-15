using Basis.Configs;
using Project.App.Configs;
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
            Container.BindInterfacesTo<ResourceProvider>().AsSingle().NonLazy();
            Container.BindInterfacesTo<BinaryConfigManager>().AsSingle().NonLazy();
        }
    }
}