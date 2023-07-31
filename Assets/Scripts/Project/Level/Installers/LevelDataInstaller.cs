using Basis.Pool;
using Basis.Views;
using Project.Level.Providers;
using UnityEngine;
using Zenject;

namespace Project.Level.Installers
{
    public sealed class LevelDataInstaller : MonoInstaller
    {
        public Camera MainCamera;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CameraProvider>().AsSingle().WithArguments(MainCamera).NonLazy();
            
            Container.BindInterfacesTo<PoolService>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<ViewsProvider>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<LevelViewsProvider>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.BindInterfacesTo<LevelDataProvider>().AsSingle().NonLazy();
        }
    }
}