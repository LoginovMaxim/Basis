using Basis.Ecs.Common.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Ecs
{
    public sealed class PrefabFactory : MonoBehaviour, IPrefabFactory
    {
	    public EcsPackedEntityWithWorld Spawn(SpawnComponent spawnComponent, Transform parent)
		{
			var gameObject = Instantiate(spawnComponent.Prefab, spawnComponent.Position, spawnComponent.Rotation, parent);

			var monoEntity = gameObject.GetComponent<MonoEntity>();
			if (monoEntity == null)
			{
				return default;
			}

			var ecsEntity = spawnComponent.World.NewEntity();
			var packedEcsEntityWithWorld = spawnComponent.World.PackEntityWithWorld(ecsEntity);
			
			monoEntity.Make(ref packedEcsEntityWithWorld);
			gameObject.AddComponent<ConvertedEntityComponent>();

			return packedEcsEntityWithWorld;
		}

	    public void Despawn(EcsPackedEntityWithWorld entity)
        {
	        if (!entity.Unpack(out var world, out var unpackedEntity))
	        {
		        return;
	        }

	        var gameObject = world.GetPool<GameObjectComponent>().Get(unpackedEntity).GameObject;
			Destroy(gameObject);
			world.DelEntity(unpackedEntity);
        }

		public void ConvertAllMonoEntitiesInScene(EcsWorld world)
		{
			var monoEntities = FindObjectsOfType<MonoEntity>();

			foreach (var monoEntity in monoEntities)
			{
				if (monoEntity.TryGetComponent<ConvertedEntityComponent>(out var convertedEntityComponent))
				{
					continue;
				}
				
				var ecsEntity = world.NewEntity();
				var packedEcsEntityWithWorld = world.PackEntityWithWorld(ecsEntity);
			
				monoEntity.Make(ref packedEcsEntityWithWorld);
				monoEntity.gameObject.AddComponent<ConvertedEntityComponent>();
			}
		}
    }
}
