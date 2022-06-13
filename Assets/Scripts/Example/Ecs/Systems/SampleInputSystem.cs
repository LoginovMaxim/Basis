using Example.Ecs.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Example.Ecs.Systems
{
    public sealed class SampleInputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        
        public void Run()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _world.NewEntity().Get<OnKeyPressedEvent>().KeyCode = KeyCode.W;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _world.NewEntity().Get<OnKeyPressedEvent>().KeyCode = KeyCode.S;
            }
            if (Input.GetKey(KeyCode.A))
            {
                _world.NewEntity().Get<OnKeyPressedEvent>().KeyCode = KeyCode.A;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _world.NewEntity().Get<OnKeyPressedEvent>().KeyCode = KeyCode.D;
            }
        }
    }
}