using System.Collections.Generic;
using System.ComponentModel;
using App.Assemblers;
using App.Fsm;
using App.Services;
using Ecs;
using Zenject;

namespace Utils
{
    public static class DiContainerExtension
    {
        public static IfNotBoundBinder BindService<TUpdatableService>(this DiContainer container, UpdateType updateType, bool isImmediateStart = false)
            where TUpdatableService : IUpdatableService
        {
            return container.BindInterfacesAndSelfTo<TUpdatableService>().AsSingle().WithArguments(updateType, isImmediateStart).NonLazy();
        }
        
        public static IAssemblerPart BindAssemblerPart<TAssemblerPart>(this DiContainer container)
            where TAssemblerPart : IAssemblerPart
        {
            container.BindInterfacesAndSelfTo<TAssemblerPart>().AsSingle().NonLazy();
            return container.Resolve<TAssemblerPart>();
        }
        
        public static IAssemblerPart BindEcsAssemblerPart<TAssemblerPart>(this DiContainer container, IWorld world, UpdateType updateType)
            where TAssemblerPart : IEcsService, IAssemblerPart
        {
            container.BindInterfacesAndSelfTo<TAssemblerPart>().AsSingle().WithArguments(world, updateType).NonLazy();
            return container.Resolve<TAssemblerPart>();
        }
        
        public static IfNotBoundBinder BindAssembler<TAssembler>(this DiContainer container, List<IAssemblerPart> assemblerPart)
            where TAssembler : Assembler
        {
            return container.BindInterfacesAndSelfTo<TAssembler>().AsSingle().WithArguments(assemblerPart).NonLazy();
        }
        
        public static TEcsWorld BindEcsWorld<TEcsWorld>(this DiContainer container)
            where TEcsWorld : World
        {
            container.BindInterfacesAndSelfTo<TEcsWorld>().AsSingle().NonLazy();
            return container.Resolve<TEcsWorld>();
        }
    }
}