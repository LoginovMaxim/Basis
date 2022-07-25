﻿using System.Collections.Generic;
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
            return container.Bind<TUpdatableService>().AsSingle().WithArguments(updateType, isImmediateStart).NonLazy();
        }
        
        public static IfNotBoundBinder BindEcsService<TWorld, TEcsService>(this DiContainer container, UpdateType updateType) 
            where TWorld : IWorld
            where TEcsService : IEcsService
        {
            var world = container.Resolve<TWorld>();
            if (world == null)
            {
                container.Bind<TWorld>().AsSingle().NonLazy();
                world = container.Resolve<TWorld>();
            }
            return container.Bind<TEcsService>().AsSingle().WithArguments(world, updateType).NonLazy();
        }
        
        public static IfNotBoundBinder BindAssembler<TAssembler>(this DiContainer container, List<IAssemblerPart> assemblerPart)
            where TAssembler : Assembler
        {
            return container.BindInterfacesAndSelfTo<TAssembler>().AsSingle().WithArguments(assemblerPart).NonLazy();
        }
    }
}