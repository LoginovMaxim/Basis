using System.Collections.Generic;
using Basis.App.Assemblers;
using Basis.App.Services;
using Basis.Ecs;
using Zenject;

namespace Basis.Utils
{
    public static class DiContainerExtension
    {
        public static IfNotBoundBinder BindService<TUpdatableService>(this DiContainer container, UpdateType updateType, bool isImmediateStart = false)
            where TUpdatableService : IUpdatableService
        {
            return container.BindInterfacesTo<TUpdatableService>().AsSingle().WithArguments(updateType, isImmediateStart).NonLazy();
        }
        
        public static IfNotBoundBinder BindEcsService<TEcsUpdatableService>(this DiContainer container, IWorld world, UpdateType updateType)
            where TEcsUpdatableService : IEcsService
        {
            return container.BindInterfacesTo<TEcsUpdatableService>().AsSingle().WithArguments(world, updateType).NonLazy();
        }
        
        public static IAssemblerPart BindAssemblerPart<TAssemblerPart>(this DiContainer container)
            where TAssemblerPart : IAssemblerPart
        {
            container.BindInterfacesAndSelfTo<TAssemblerPart>().AsSingle().NonLazy();
            return container.Resolve<TAssemblerPart>();
        }
        
        public static IfNotBoundBinder BindAssembler<TAssembler>(this DiContainer container, List<IAssemblerPart> assemblerPart)
            where TAssembler : Assembler
        {
            return container.BindInterfacesTo<TAssembler>().AsSingle().WithArguments(assemblerPart).NonLazy();
        }
        
        public static TEcsWorld BindEcsWorld<TEcsWorld>(this DiContainer container)
            where TEcsWorld : WorldBase
        {
            container.BindInterfacesAndSelfTo<TEcsWorld>().AsSingle().NonLazy();
            return container.Resolve<TEcsWorld>();
        }
    }
}