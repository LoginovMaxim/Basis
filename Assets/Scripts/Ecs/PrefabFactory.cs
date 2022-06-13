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

		private void Spawn(SpawnComponent spawnComponent)
		{
			var gameObject = Instantiate(spawnComponent.Prefab, spawnComponent.Position, spawnComponent.Rotation, spawnComponent.Parent);
			gameObject.transform.localScale = spawnComponent.Scale;

			var monoEntity = gameObject.GetComponent<MonoEntity>();
			if (monoEntity == null)
			{
				return;
			}

			var ecsEntity = _world.NewEntity();
			monoEntity.Make(ref ecsEntity);
			
			var monoChildrenEntities = gameObject.GetComponentsInChildren<MonoEntity>(true);
			foreach (var monoChildrenEntity in monoChildrenEntities)
			{
				monoChildrenEntity.Make(ref ecsEntity);
			}
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
				var ecsEntity = _world.NewEntity();
				monoEntity.Make(ref ecsEntity);
			}
		}

		#region IPrefabFactory

		void IPrefabFactory.SetWorld(EcsWorld world)
		{
			SetWorld(world);
		}

		void IPrefabFactory.Spawn(SpawnComponent spawnComponent)
		{
			Spawn(spawnComponent);
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
