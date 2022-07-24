using Ecs;
using Example.App.Assemblers;
using Example.App.Services;
using Example.Ecs;
using Example.Ecs.Configs;
using Utils;
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

            // ecs worlds
            Container.Bind<MainWorld>().AsSingle().NonLazy();
            
            // services
            Container.Bind<SampleService>().AsSingle().NonLazy();
            Container.BindEcsService<MainWorld, SampleEcsService>();
            
            // assembler
            Container.Bind<SampleAssembler>().AsSingle().NonLazy();
        }
    }
}