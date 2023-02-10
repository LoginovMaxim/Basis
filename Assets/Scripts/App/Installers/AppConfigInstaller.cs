using App.Configs;
using Zenject;
using ResourceProvider = App.Configs.ResourceProvider;

namespace App.Installers
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