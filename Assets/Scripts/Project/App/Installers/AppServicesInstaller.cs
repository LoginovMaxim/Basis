using Basis.Localizations;
using Basis.VisualEffects;
using Zenject;

namespace Basis.Installers
{
    public sealed class AppServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EffectEmitter>().AsSingle().NonLazy();
            Container.BindInterfacesTo<Localization>().AsSingle().NonLazy();
        }
    }
}