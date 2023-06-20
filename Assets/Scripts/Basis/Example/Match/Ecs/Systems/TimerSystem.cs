using Leopotam.EcsLite;
using UnityEngine;

namespace Basis.Example.Match.Ecs.Systems
{
    public sealed class TimerSystem : IEcsRunSystem
    {
        #region Constants

        private const int OneSecond = 1;

        #endregion

        private float _elapsedTime = OneSecond;
        private int _seconds;

        public void Run(IEcsSystems systems)
        {
            _elapsedTime -= Time.deltaTime;
            if (_elapsedTime > 0)
            {
                return;
            }

            _elapsedTime = OneSecond;
            _seconds++;
        }
    }
}