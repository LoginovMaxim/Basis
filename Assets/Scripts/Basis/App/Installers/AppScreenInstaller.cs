using Basis.App.UI.Signals;
using UnityEngine;
using Zenject;

namespace Basis.App.Installers
{
    public sealed class AppScreenInstaller : MonoInstaller
    {
        public Transform ScreenParent;
        
        public override void InstallBindings()
        {
            Container.DeclareSignal<SwitchScreenSignal>();
            
            //Container.BindInterfacesTo<ScreenService>().AsSingle().NonLazy();
        }
    }
}