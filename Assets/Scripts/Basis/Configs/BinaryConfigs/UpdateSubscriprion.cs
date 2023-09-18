using System;

namespace Basis.Configs.BinaryConfigs
{
    public class UpdateSubscriprion : Handle
    {
        private readonly Action _onUpdate;

        public UpdateSubscriprion(string requester, Action onUpdate)
            : base(requester)
        {
            _onUpdate = onUpdate;
        }

        public void Notify()
        {
            _onUpdate?.Invoke();
        }
    }
}