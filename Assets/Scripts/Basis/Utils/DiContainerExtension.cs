using System.Collections.Generic;
using Basis.Assemblers;
using Basis.Assemblers.Launchers;
using Basis.Ecs;
using Basis.Pool;
using Basis.Services;
using Basis.UI.Screens;
using Basis.Views;
using Project.App.Data;
using Zenject;

namespace Basis.Utils
{
    public static class DiContainerExtension
    {
        public static void BindService<TUpdatableService>(this DiContainer container, UpdateType updateType)
            where TUpdatableService : IUpdatableService
        {
            container.BindInterfacesTo<TUpdatableService>().AsSingle().WithArguments(updateType).NonLazy();
        }
        
        public static void BindEcsService<TEcsUpdatableService>(this DiContainer container, IEcsWorld ecsWorld, UpdateType updateType)
            where TEcsUpdatableService : IEcsService
        {
            container.BindInterfacesTo<TEcsUpdatableService>().AsSingle().WithArguments(ecsWorld, updateType).NonLazy();
        }
        
        public static IAssemblerLauncher BindAssemblerLauncher<TAssemblerLauncher>(this DiContainer container)
            where TAssemblerLauncher : IAssemblerLauncher
        {
            container.BindInterfacesAndSelfTo<TAssemblerLauncher>().AsSingle().NonLazy();
            return container.Resolve<TAssemblerLauncher>();
        }
        
        public static void BindAssembler<TAssembler>(this DiContainer container, List<IAssemblerLauncher> assemblerPart)
            where TAssembler : Assembler
        {
            container.BindInterfacesTo<TAssembler>().AsSingle().WithArguments(assemblerPart).NonLazy();
        }
        
        public static void BindViewPool<TViewObject, TViewPool>(this DiContainer container, int initialSize = 0)
            where TViewObject : IViewObject 
            where TViewPool : ViewPool<TViewObject>
        {
            var resourcePath = typeof(TViewObject).ToString().GetTypeName();
            
            container.BindMemoryPool<TViewObject, TViewPool>().WithInitialSize(initialSize)
                .FromComponentInNewPrefabResource(resourcePath).AsCached().NonLazy();
            
            var viewPool = container.Resolve<TViewPool>();
            var poolService = container.Resolve<IPoolService>();

            poolService.TryAddViewPool(typeof(TViewObject), viewPool);
        }
        
        public static void BindScreen<TScreen>(
            this DiContainer container, 
            int id, 
            ScreenShowingType screenShowingType = Constants.ScreenAnimation.DefaultScreenShowingType, 
            ScreenHidingType screenHidingType = Constants.ScreenAnimation.DefaultScreenHidingType)
            where TScreen : IScreen
        {
            container.BindInterfacesAndSelfTo<TScreen>().AsSingle().NonLazy();
            var screen = container.Resolve<TScreen>();
            screen.Init(id, screenShowingType, screenHidingType);
        }
    }
}