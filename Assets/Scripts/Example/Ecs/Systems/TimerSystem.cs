using Leopotam.Ecs;
using UnityEngine;

namespace Example.Ecs.Systems
{
    public sealed class TimerSystem : IEcsRunSystem
    {
        #region Constants

        private const int OneSecond = 1;

        #endregion
        
        private readonly EcsWorld _world = null;

        private float _elapsedTime = OneSecond;
        private int _seconds;
        
        public void Run()
        {
            _elapsedTime -= Time.deltaTime;
            if (_elapsedTime > 0)
            {
                return;
            }

            _elapsedTime = OneSecond;
            _seconds++;
            
            Debug.Log($"[TimerSystem] Elapsed seconds {_seconds}");
        }
    }
}