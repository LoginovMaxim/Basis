using Ecs.Common.Components;
using Leopotam.Ecs;
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

		private EcsEntity Spawn(SpawnComponent spawnComponent, Transform parent)
		{
			var gameObject = Instantiate(spawnComponent.Prefab, spawnComponent.Position, spawnComponent.Rotation, parent);

			var monoEntity = gameObject.GetComponent<MonoEntity>();
			if (monoEntity == null)
			{
				return default;
			}

			var ecsEntity = _world.NewEntity();
			monoEntity.Make(ref ecsEntity);
			gameObject.AddComponent<ConvertedEntityComponent>();

			return ecsEntity;
		}

		private void Despawn(EcsEntity entity)
        {
			Destroy(entity.Get<GameObjectComponent>().GameObject);
			entity.Destroy();
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
				monoEntity.Make(ref ecsEntity);
				monoEntity.gameObject.AddComponent<ConvertedEntityComponent>();
			}
		}

		#region IPrefabFactory

		void IPrefabFactory.SetWorld(EcsWorld world)
		{
			SetWorld(world);
		}

		EcsEntity IPrefabFactory.Spawn(SpawnComponent spawnComponent, Transform parent)
		{
			return Spawn(spawnComponent, parent);
		}

		void IPrefabFactory.Despawn(EcsEntity entity)
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
