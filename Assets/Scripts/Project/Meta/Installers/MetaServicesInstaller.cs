using BasisCore.Runtime.Extensions;
using Project.Meta.UI;
using Project.Meta.UI.Main;
using Project.Meta.UI.Shop;
using Zenject;

namespace Project.Meta.Installers
{
    public sealed class MetaServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindScreens();
            BindScreenService();
        }

        private void BindScreens()
        {
            Container.BindScreenController<MainScreenController>((int) MetaScreenId.Main);
            Container.BindScreenController<ShopScreenController>((int) MetaScreenId.Shop);
        }

        private void BindScreenService()
        {
            Container.BindInterfacesTo<MetaBaseScreenService>().AsSingle().NonLazy();
        }
    }
}