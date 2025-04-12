using Zenject;

namespace Basis.Meta.Installers
{
    public sealed class MetaUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindModels();
        }

        private void BindModels()
        {
        }
    }
}