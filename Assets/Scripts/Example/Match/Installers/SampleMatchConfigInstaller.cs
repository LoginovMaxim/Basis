using Example.Match.Ecs.Configs;
using Zenject;

namespace Example.Match.Installers
{
    public sealed class SampleMatchConfigInstaller : MonoInstaller
    {
        public MapConfig MapConfig;
        public ShipPrefabConfig ShipPrefabConfig;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MapConfig>().FromScriptableObject(MapConfig).AsSingle();
            Container.BindInterfacesTo<ShipPrefabConfig>().FromScriptableObject(ShipPrefabConfig).AsSingle().NonLazy();
        }
    }
}