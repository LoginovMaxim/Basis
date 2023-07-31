using System;
using UnityEngine;

namespace Basis.Monos
{
    public class ApplicationStatusHandler : MonoBehaviour, IApplicationStatusHandler
    {
        public event Action<bool> OnApplicationPauseStatusChanged;
        public event Action<bool> OnApplicationFocusStatusChanged;
        public event Action OnApplicationQuitted;

        private void OnApplicationPause(bool pauseStatus)
        {
            OnApplicationPauseStatusChanged?.Invoke(pauseStatus);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            OnApplicationFocusStatusChanged?.Invoke(hasFocus);
        }

        private void OnApplicationQuit()
        {
            OnApplicationQuitted?.Invoke();
        }
    }
}