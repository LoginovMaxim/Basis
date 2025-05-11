using Basis.Core.Configs;
using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreConfigInstaller : MonoInstaller
    {
        public ContentMap ContentMap;

        public override void InstallBindings()
        {
            Instantiate(ContentMap);
        }
    }
}