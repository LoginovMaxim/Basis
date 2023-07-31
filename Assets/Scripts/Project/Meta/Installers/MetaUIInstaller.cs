using Basis.Utils;
using Project.Meta.UI;
using Project.Meta.UI.Main;
using Project.Meta.UI.Shop;
using Zenject;

namespace Project.Meta.Installers
{
    public sealed class MetaUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindViewModels();
            BindScreens();
            BindScreenService();
        }

        private void BindViewModels()
        {
            Container.Bind<MainScreenViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();  
            Container.Bind<ShopScreenViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();  
        }

        private void BindScreens()
        {
            Container.BindScreen<MainScreen>((int) MetaScreenId.Main);
            Container.BindScreen<ShopScreen>((int) MetaScreenId.Shop);
        }

        private void BindScreenService()
        {
            Container.BindInterfacesTo<MetaScreenService>().AsSingle().NonLazy();
        }
    }
}