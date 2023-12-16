using BasisCore.Runtime.Utils;
using Project.Match.UI;
using Project.Match.UI.Gameplay;
using Zenject;

namespace Project.Match.Installers
{
    public sealed class MatchServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindScreens();
            BindScreenService();
        }

        private void BindScreens()
        {
            Container.BindScreenController<GameplayScreenController>((int) MatchScreenId.Gameplay);
        }

        private void BindScreenService()
        {
            Container.BindInterfacesTo<MatchBaseScreenService>().AsSingle().NonLazy();
        }
    }
}