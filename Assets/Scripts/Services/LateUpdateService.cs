using System;
using Monos;

namespace Services
{
    public abstract class LateUpdateService : Service, IDisposable
    {
        private readonly MonoUpdater _monoUpdater;
        
        public LateUpdateService(MonoUpdater monoUpdater)
        {
            _monoUpdater = monoUpdater;
            _monoUpdater.LateUpdated += Run;
        }

        public virtual void Dispose()
        {
            _monoUpdater.LateUpdated -= Run;
        }
        
    }
}