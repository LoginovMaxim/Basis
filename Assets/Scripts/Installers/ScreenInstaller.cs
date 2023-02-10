using App.UI.Signals;
using UnityEngine;
using Zenject;

namespace Installers
{
    public sealed class ScreenInstaller : MonoInstaller
    {
        public Transform ScreenParent;
        
        public override void InstallBindings()
        {
            Container.DeclareSignal<SwitchScreenSignal>();
            
            //Container.BindInterfacesTo<ScreenService>().AsSingle().NonLazy();
        }
    }
}