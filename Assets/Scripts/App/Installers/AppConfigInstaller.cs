using BasisCore.Runtime.Configs.UI;
using BasisCore.Runtime.ResourceProviders;
using Zenject;

namespace App.Installers
{
    public sealed class AppConfigInstaller : MonoInstaller
    {
        public ScreenAnimationConfig ScreenAnimationConfig;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AddressableResourceProvider>().AsSingle().NonLazy();
        }
    }
}