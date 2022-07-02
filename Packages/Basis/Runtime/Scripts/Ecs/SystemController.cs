using Leopotam.Ecs;

namespace Ecs
{
    public class SystemController : ISystemController
    {
        private EcsSystems _ecsSystems;

        public SystemController(EcsSystems ecsSystems)
        {
            _ecsSystems = ecsSystems;
        }

        private void SetSystemState(string systemName, bool state)
        {
            var index = _ecsSystems.GetNamedRunSystem(systemName);
            if (index < 0)
            {
                return;
            }

            _ecsSystems.SetRunSystemState(index, state);
        }

        #region ISystemController

        void ISystemController.SetSystemState(string systemName, bool state)
        {
            SetSystemState(systemName, state);
        }

        #endregion
    }
}