using System;

namespace App.Configs
{
    public class Handle : IHandle
    {
        private readonly string _requester;
        private readonly Action<IHandle> _onDispose;

        private bool _disposed;

        public bool Disposed => _disposed;

        public Handle()
            : this(string.Empty)
        {
        }

        public Handle(string requester)
            : this(requester, null)
        {
        }

        public Handle(string requester, Action<IHandle> onDispose)
        {
            _requester = requester;
            _onDispose = onDispose;
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;
            _onDispose?.Invoke(this);
        }
    }
}