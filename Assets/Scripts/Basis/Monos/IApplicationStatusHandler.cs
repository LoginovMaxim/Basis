using System;

namespace Basis.Monos
{
    public interface IApplicationStatusHandler
    {
        event Action<bool> OnApplicationPauseStatusChanged;
        public event Action<bool> OnApplicationFocusStatusChanged;
        public event Action OnApplicationQuitted;
    }
}