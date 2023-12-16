using BasisCore.Runtime.Localizations;
using BasisCore.Runtime.SceneLoaders;
using BasisCore.Runtime.VisualEffects;
using Project.App.Services;
using Zenject;

namespace Project.App.Installers
{
    public sealed class AppServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Localization>().AsSingle().NonLazy();
            Container.BindInterfacesTo<AddressableSceneLoader>().AsSingle().NonLazy();
            Container.BindInterfacesTo<MetaSceneLoader>().AsSingle().NonLazy();
            Container.BindInterfacesTo<MatchSceneLoader>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EffectEmitter>().AsSingle().NonLazy();
        }
    }
}