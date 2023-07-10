using Basis.UI.Screens;
using Basis.UI.Screens.Animations.Hiding;
using Basis.UI.Screens.Animations.Showing;
using Basis.UI.Splashes;
using Zenject;

namespace Project.App.Installers
{
    public sealed class AppUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSplash();
            BindScreenAnimators();
        }

        private void BindSplash()
        {
            Container.BindInterfacesAndSelfTo<AppSplashViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<Splash<AppSplashViewModel>>().AsSingle().NonLazy();
        }

        private void BindScreenAnimators()
        {
            Container.BindInterfacesTo<FadeOutShowingScreenAnimator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<FromLeftShowingScreenAnimator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<FromRightShowingScreenAnimator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<FromUpShowingScreenAnimator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<FromDownShowingScreenAnimator>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<FadeInHidingScreenAnimator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ToLeftHidingScreenAnimator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ToRightHidingScreenAnimator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ToUpHidingScreenAnimator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ToDownHidingScreenAnimator>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<ScreenAnimationService>().AsSingle().NonLazy();
        }
    }
}