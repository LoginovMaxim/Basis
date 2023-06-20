using Basis.Example.Meta.UI;
using Basis.Example.Meta.UI.ChestScreen;
using Basis.Example.Meta.UI.MainScreen;
using Basis.Example.Meta.UI.ShopScreen;
using Zenject;

namespace Basis.Example.Meta.Installers
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