using Project.Meta.UI.Main;
using Project.Meta.UI.Shop;
using Zenject;

namespace Project.Meta.Installers
{
    public sealed class MetaUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindModels();
            BindViews();
        }

        private void BindModels()
        {
            Container.Bind<MainScreenModel>().AsSingle().NonLazy();  
            Container.Bind<ShopScreenModel>().AsSingle().NonLazy();  
        }

        private void BindViews()
        {
            Container.Bind<MainScreenView>().FromComponentInHierarchy().AsSingle().NonLazy();  
            Container.Bind<ShopScreenView>().FromComponentInHierarchy().AsSingle().NonLazy();  
        }
    }
}