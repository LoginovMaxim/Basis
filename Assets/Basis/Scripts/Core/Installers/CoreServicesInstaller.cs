using Basis.Core.Services;
using BasisCore.Localizations;
using BasisCore.SceneLoaders;
using BasisCore.VisualEffects;
using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreServicesInstaller : MonoInstaller
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