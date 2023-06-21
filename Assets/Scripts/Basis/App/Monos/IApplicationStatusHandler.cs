using System;

namespace Basis.App.Monos
{
    public interface IApplicationStatusHandler
    {
        event Action<bool> OnApplicationPauseStatusChanged;
        public event Action<bool> OnApplicationFocusStatusChanged;
        public event Action OnApplicationQuitted;
    }
}