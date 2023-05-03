using Example.Ecs.Events;
using Leopotam.EcsLite;
using UnityEngine;

namespace Example.Ecs.Systems
{
    public sealed class SampleInputSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                CreateInputEntity(systems, KeyCode.W);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                CreateInputEntity(systems, KeyCode.S);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                CreateInputEntity(systems, KeyCode.A);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                CreateInputEntity(systems, KeyCode.D);
            }
        }

        private void CreateInputEntity(IEcsSystems systems, KeyCode keyCode)
        {
            var world = systems.GetWorld();
            var keyPressedEvents = world.GetPool<OnKeyPressedEvent>();
            
            var entity = world.NewEntity(); 
            ref var keyPressedEvent = ref keyPressedEvents.Add(entity);
            keyPressedEvent.KeyCode = keyCode;
        }
    }
}