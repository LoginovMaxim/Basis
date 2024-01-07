using Project.Meta.UI.Main;
using Zenject;

namespace Project.Meta.Installers
{
    public sealed class MetaUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindModels();
        }

        private void BindModels()
        {
            Container.Bind<MetaMainWindowModel>().AsSingle().NonLazy();  
            Container.Bind<MetaMainWindow>().AsSingle().NonLazy();  
        }
    }
}