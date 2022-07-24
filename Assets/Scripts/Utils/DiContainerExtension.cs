using Ecs;
using Zenject;

namespace Utils
{
    public static class DiContainerExtension
    {
        public static IfNotBoundBinder BindEcsService<TWorld, TEcsService>(this DiContainer container) 
            where TWorld : IWorld
            where TEcsService : IEcsService
        {
            var world = container.Resolve<TWorld>();
            return container.Bind<TEcsService>().AsSingle().WithArguments(world).NonLazy();
        }
    }
}