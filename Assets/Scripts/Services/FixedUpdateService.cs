using System;
using Monos;

namespace Services
{
    public abstract class FixedUpdateService : Service, IDisposable
    {
        private readonly MonoUpdater _monoUpdater;
        
        public FixedUpdateService(MonoUpdater monoUpdater)
        {
            _monoUpdater = monoUpdater;
            _monoUpdater.FixedUpdated += Run;
        }

        public virtual void Dispose()
        {
            _monoUpdater.FixedUpdated -= Run;
        }
    }
}