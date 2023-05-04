using Example.Meta.UI;
using Example.Meta.UI.ChestScreen;
using Example.Meta.UI.MainScreen;
using Example.Meta.UI.ShopScreen;
using Zenject;

namespace Example.Meta.Installers
{
    public sealed class SampleMetaUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SampleMainScreenViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SampleShopScreenViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SampleChestScreenViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<SampleMainScreen>().AsSingle().WithArguments((int) SampleMetaScreenId.Main).NonLazy();
            Container.BindInterfacesTo<SampleShopScreen>().AsSingle().WithArguments((int) SampleMetaScreenId.Shop).NonLazy();
            Container.BindInterfacesTo<SampleChestScreen>().AsSingle().WithArguments((int) SampleMetaScreenId.Chest).NonLazy();
            
            Container.BindInterfacesTo<SampleMetaScreenService>().AsSingle().NonLazy();
        }
    }
}