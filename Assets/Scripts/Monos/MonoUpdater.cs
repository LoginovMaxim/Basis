using System;
using FSM;
using UnityEngine;

namespace Monos
{
    public class MonoUpdater : MonoBehaviour
    {
        public event Action Updated;
        public event Action FixedUpdated;
        public event Action LateUpdated;

        private void Awake() => DontDestroyOnLoad(gameObject);

        private void Update() { Updated?.Invoke(); }
        private void FixedUpdate() { FixedUpdated?.Invoke(); }
        private void LateUpdate() { LateUpdated?.Invoke(); }

        public void Subscribe(UpdateType updateType, Action action)
        {
            switch (updateType)
            {
                case UpdateType.Update:
                    Updated += action;
                    break;
                case UpdateType.FixedUpdate:
                    FixedUpdated += action;
                    break;
                case UpdateType.LateUpdate:
                    LateUpdated += action;
                    break;
            }
        }
        
        public void Unsubscribe(UpdateType updateType, Action action)
        {
            switch (updateType)
            {
                case UpdateType.Update:
                    Updated -= action;
                    break;
                case UpdateType.FixedUpdate:
                    FixedUpdated -= action;
                    break;
                case UpdateType.LateUpdate:
                    LateUpdated -= action;
                    break;
            }
        }
    }
}
