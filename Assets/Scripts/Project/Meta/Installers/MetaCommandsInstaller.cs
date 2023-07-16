using Project.Meta.Commands;
using Zenject;

namespace Project.Meta.Installers
{
    public sealed class MetaCommandsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayMatchCommand>().AsSingle().NonLazy();
        }
    }
}