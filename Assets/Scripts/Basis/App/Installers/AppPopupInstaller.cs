using Basis.App.UI.Commands;
using Basis.App.UI.Popups.Logics;
using Basis.App.UI.Popups.ViewModels;
using Basis.App.UI.Services;
using Basis.App.UI.Signals;
using UnityEngine;
using Zenject;

namespace Basis.App.Installers
{
    public sealed class AppPopupInstaller : MonoInstaller
    {
        public Transform PopupParent;
        
        public IconPopupViewModel IconPopupViewModel;
        
        public override void InstallBindings()
        {
            Container.DeclareSignal<ClosePopupSignal>();

            Container.Bind<ShowIconPopupCommand>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<IconPopup>().AsSingle().NonLazy();
            Container.BindInterfacesTo<PopupService>().AsSingle().NonLazy();
            
            Container
                .BindMemoryPool<IconPopupViewModel, IconPopupViewModel.Pool>()
                .FromComponentInNewPrefab(IconPopupViewModel)
                .UnderTransform(PopupParent)
                .AsCached()
                .NonLazy();
        }
    }
}