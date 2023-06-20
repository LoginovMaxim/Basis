using Basis.Ecs.Pool;
using Basis.Example.Match.Pools.Ships;
using UnityEngine;
using Zenject;

namespace Basis.Example.Match.Installers
{
    public sealed class SampleMatchPoolsInstaller : MonoInstaller
    {
        public Transform SmallShipParent;
        public Transform BigShipParent;
        
        public override void InstallBindings()
        {
            Container.Bind<SmallShip>().AsSingle().WithArguments(ShipId.SmallShip, 10).NonLazy();
            Container.Bind<BigShip>().AsSingle().WithArguments(ShipId.BigShip, 5).NonLazy();
            
            Container.BindInterfacesTo<EntityPool<SmallShip>>().AsSingle().WithArguments(SmallShipParent).NonLazy();
            Container.BindInterfacesTo<EntityPool<BigShip>>().AsSingle().WithArguments(BigShipParent).NonLazy();
            
            Container.BindInterfacesTo<ShipPool>().AsSingle().NonLazy();
        }
    }
}