using Basis.UI.Signals;
using Zenject;

namespace Basis.Installers
{
    public sealed class AppSignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.DeclareSignal<SwitchScreenSignal>();
        }
    }
}