using Assemblers;

namespace Services
{
    public abstract class Service : AssemblerPart, IService
    {
        public bool IsPaused => _isPaused;

        private bool _isPaused = true;

        protected void Run()
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
    }
}