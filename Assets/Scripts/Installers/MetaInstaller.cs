using Assemblers;
using ViewModels;
using Zenject;

namespace Installers
{
    public class MetaInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Localization>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MetaAssembler>().AsSingle().NonLazy();
        }
    }
}