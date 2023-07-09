using Basis.Localizations;
using Basis.VisualEffects;
using Project.App.Services;
using Zenject;

namespace Project.App.Installers
{
    public sealed class AppServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Localization>().AsSingle().NonLazy();
            Container.BindInterfacesTo<MetaSceneLoader>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EffectEmitter>().AsSingle().NonLazy();
        }
    }
}