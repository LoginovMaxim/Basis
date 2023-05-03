using Ecs.Common.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Ecs
{
    public sealed class PrefabFactory : MonoBehaviour, IPrefabFactory
    {
		private EcsWorld _world;

		private void SetWorld(EcsWorld world)
		{
			_world = world;
		}

		private EcsPackedEntityWithWorld Spawn(SpawnComponent spawnComponent, Transform parent)
		{
			var gameObject = Instantiate(spawnComponent.Prefab, spawnComponent.Position, spawnComponent.Rotation, parent);

			var monoEntity = gameObject.GetComponent<MonoEntity>();
			if (monoEntity == null)
			{
				return default;
			}

			var ecsEntity = _world.NewEntity();
			var packedEcsEntityWithWorld = _world.PackEntityWithWorld(ecsEntity);
			
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

		private void ConvertAllMonoEntitiesInScene()
		{
			var monoEntities = FindObjectsOfType<MonoEntity>();

			foreach (var monoEntity in monoEntities)
			{
				if (monoEntity.TryGetComponent<ConvertedEntityComponent>(out var convertedEntityComponent))
				{
					continue;
				}
				
				var ecsEntity = _world.NewEntity();
				var packedEcsEntityWithWorld = _world.PackEntityWithWorld(ecsEntity);
			
				monoEntity.Make(ref packedEcsEntityWithWorld);
				monoEntity.gameObject.AddComponent<ConvertedEntityComponent>();
			}
		}

		#region IPrefabFactory

		void IPrefabFactory.SetWorld(EcsWorld world)
		{
			SetWorld(world);
		}

		EcsPackedEntityWithWorld IPrefabFactory.Spawn(SpawnComponent spawnComponent, Transform parent)
		{
			return Spawn(spawnComponent, parent);
		}

		void IPrefabFactory.Despawn(EcsPackedEntityWithWorld entity)
		{
			Despawn(entity);
		}

		void IPrefabFactory.ConvertAllMonoEntitiesInScene()
		{
			ConvertAllMonoEntitiesInScene();
		}

		#endregion
    }
}
