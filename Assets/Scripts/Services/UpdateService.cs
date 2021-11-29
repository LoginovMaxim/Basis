using System;

namespace Services
{
    public abstract class UpdateService : Service, IDisposable
    {
        private readonly MonoUpdater _monoUpdater;
        
        public UpdateService(MonoUpdater monoUpdater)
        {
            _monoUpdater = monoUpdater;
            _monoUpdater.Updated += Run;
        }

        public virtual void Dispose()
        {
            _monoUpdater.Updated -= Run;
        }
    }
}