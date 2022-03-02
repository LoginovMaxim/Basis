using CoreECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace CoreECS
{
    public sealed class PrefabFactory : MonoBehaviour
    {
		private EcsWorld _world;

		public void SetWorld(EcsWorld world)
		{
			_world = world;
		}

		public void Spawn(SpawnComponent spawnComponent)
		{
			var gameObject = Instantiate(spawnComponent.Prefab, spawnComponent.Position, spawnComponent.Rotation, spawnComponent.Parent);
			gameObject.transform.localScale = spawnComponent.Scale;

			var monoEntity = gameObject.GetComponent<MonoEntity>();
			if (monoEntity == null)
				return;

			var ecsEntity = _world.NewEntity();
			monoEntity.Make(ref ecsEntity);
		}

		public void Despawn(EcsEntity entity)
        {
			Destroy(entity.Get<GameObjectComponent>().GameObject);
			entity.Destroy();
        }
    }
}
