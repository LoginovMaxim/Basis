using App.Fsm;
using App.Services;
using Ecs;
using Zenject;

namespace Utils
{
    public static class DiContainerExtension
    {
        public static IfNotBoundBinder BindService<TUpdatableService>(this DiContainer container, UpdateType updateType)
            where TUpdatableService : IUpdatableService
        {
            return container.Bind<TUpdatableService>().AsSingle().WithArguments(updateType).NonLazy();
        }
        
        public static IfNotBoundBinder BindEcsService<TWorld, TEcsService>(this DiContainer container, UpdateType updateType) 
            where TWorld : IWorld
            where TEcsService : IEcsService
        {
            var world = container.Resolve<TWorld>();
            return container.Bind<TEcsService>().AsSingle().WithArguments(world, updateType).NonLazy();
        }
    }
}