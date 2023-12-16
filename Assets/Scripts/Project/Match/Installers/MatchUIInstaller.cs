using Project.Match.UI.Gameplay;
using Zenject;

namespace Project.Match.Installers
{
    public sealed class MatchUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindModels();
            BindViews();
        }

        private void BindModels()
        {
            Container.Bind<GameplayScreenModel>().AsSingle().NonLazy();  
        }

        private void BindViews()
        {
            Container.Bind<GameplayScreenView>().FromComponentInHierarchy().AsSingle().NonLazy();  
        }
    }
}