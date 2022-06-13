using Example.App.Assemblers;
using Example.App.Services;
using Example.Ecs;
using Example.Ecs.Configs;
using Zenject;

namespace Example.Installers
{
    public sealed class SampleInstaller : MonoInstaller
    {
        public MapConfig MapConfig;

        public override void InstallBindings()
        {
            // configs
            Container.BindInterfacesTo<MapConfig>().FromScriptableObject(MapConfig).AsSingle();
            
            // services
            Container.Bind<SampleService>().AsSingle().NonLazy();
            Container.Bind<SampleEcsWorldService>().AsSingle().NonLazy();
            
            // assembler
            Container.Bind<SampleAssembler>().AsSingle().NonLazy();
        }
    }
}