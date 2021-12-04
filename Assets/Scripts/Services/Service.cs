using System;
using Assemblers;
using FSM;
using Monos;

namespace Services
{
    public abstract class Service : AssemblerPart, IService, IDisposable
    {
        public virtual UpdateType UpdateType => UpdateType.Update;
        public bool IsPaused => _isPaused;

        private readonly MonoUpdater _monoUpdater;

        private bool _isPaused = true;
        
        protected Service(MonoUpdater monoUpdater)
        {
            _monoUpdater = monoUpdater;
            _monoUpdater.Subscribe(UpdateType, Run);
        }
        
        private void Run()
        {
            if (_isPaused)
                return;

            ProcessRun();
        }

        protected abstract void ProcessRun();

        public void Start()
        {
            Pause(false);
        }

        public void Pause(bool isPaused) => _isPaused = isPaused;

        public virtual void Dispose()
        {
            _monoUpdater.Unsubscribe(UpdateType, Run);
        }
    }
}