using Basis.Level.Providers;
using UnityEngine;
using Zenject;

namespace Basis.Level.Installers
{
    public sealed class LevelDataInstaller : MonoInstaller
    {
        public Camera MainCamera;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CameraProvider>().AsSingle().WithArguments(MainCamera).NonLazy();
            
            Container.BindInterfacesTo<LevelViewsProvider>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.BindInterfacesTo<LevelDataProvider>().AsSingle().NonLazy();
        }
    }
}