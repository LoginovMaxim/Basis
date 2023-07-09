using Basis.Signals;
using Zenject;

namespace Project.App.Installers
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