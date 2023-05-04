using Example.Meta.Commands;
using Zenject;

namespace Example.Meta.Installers
{
    public sealed class SampleMetaCommandsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayMatchSampleCommand>().AsSingle().NonLazy();
        }
    }
}