using Example.App.UI.Screens;
using Example.App.UI.Screens.Logics;
using Example.App.UI.Screens.ViewModels;
using Zenject;

namespace Example.Installers
{
    public sealed class SampleUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<FirstExampleScreenViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<SecondExampleScreenViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<FirstExampleScreen>().AsSingle().WithArguments((int) ExampleScreenId.FirstScreen).NonLazy();
            Container.BindInterfacesTo<SecondExampleScreen>().AsSingle().WithArguments((int) ExampleScreenId.SecondScreen).NonLazy();
            
            Container.BindInterfacesTo<ExampleScreenService>().AsSingle().NonLazy();
        }
    }
}