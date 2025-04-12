using BasisCore.ResourceProviders;
using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreConfigInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AddressableResourceProvider>().AsSingle().NonLazy();
        }
    }
}