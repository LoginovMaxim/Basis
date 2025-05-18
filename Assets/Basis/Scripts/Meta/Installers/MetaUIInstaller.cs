using Basis.Meta.UI;
using Zenject;

namespace Basis.Meta.Installers
{
    public sealed class MetaUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MetaMainWindowModel>().AsSingle();
            Container.Bind<IMetaMainWindowViewModel>().To<MetaMainWindowViewModel>().AsSingle();
            Container.Bind<IMetaSettingsPopupViewModel>().To<MetaSettingsPopupViewModel>().AsSingle();
        }
    }
}