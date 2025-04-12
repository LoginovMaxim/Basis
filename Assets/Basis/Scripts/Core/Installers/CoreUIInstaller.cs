using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSplash();
            BindScreenAnimators();
        }

        private void BindSplash()
        {
        }

        private void BindScreenAnimators()
        {
        }
    }
}