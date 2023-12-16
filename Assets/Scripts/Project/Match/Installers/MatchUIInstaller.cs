using BasisCore.Runtime.Utils;
using Project.Match.UI;
using Project.Match.UI.Gameplay;
using Zenject;

namespace Project.Match.Installers
{
    public sealed class MatchUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindViewModels();
            BindScreens();
            BindScreenService();
        }

        private void BindViewModels()
        {
            Container.Bind<GameplayScreenViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();  
        }

        private void BindScreens()
        {
            Container.BindScreen<GameplayScreen>((int) MatchScreenId.Gameplay);
        }

        private void BindScreenService()
        {
            Container.BindInterfacesTo<MatchScreenService>().AsSingle().NonLazy();
        }
    }
}