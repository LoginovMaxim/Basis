using Basis.Ecs.Common.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Ecs
{
    public sealed class PrefabFactory : MonoBehaviour, IPrefabFactory
    {
	    private EcsPackedEntityWithWorld Spawn(SpawnComponent spawnComponent, Transform parent)
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

		private void Despawn(EcsPackedEntityWithWorld entity)
        {
	        if (!entity.Unpack(out var world, out var unpackedEntity))
	        {
		        return;
	        }

	        var gameObject = world.GetPool<GameObjectComponent>().Get(unpackedEntity).GameObject;
			Destroy(gameObject);
			world.DelEntity(unpackedEntity);
        }

		private void ConvertAllMonoEntitiesInScene(EcsWorld world)
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

		#region IPrefabFactory

		EcsPackedEntityWithWorld IPrefabFactory.Spawn(SpawnComponent spawnComponent, Transform parent)
		{
			return Spawn(spawnComponent, parent);
		}

		void IPrefabFactory.Despawn(EcsPackedEntityWithWorld entity)
		{
			Despawn(entity);
		}

		void IPrefabFactory.ConvertAllMonoEntitiesInScene(EcsWorld world)
		{
			ConvertAllMonoEntitiesInScene(world);
		}

		#endregion
    }
}
