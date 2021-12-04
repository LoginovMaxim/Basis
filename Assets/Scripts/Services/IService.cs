using FSM;

namespace Services
{
    public interface IService
    {
        UpdateType UpdateType { get; }
        bool IsPaused { get; }
        
        void Start();
        void Pause(bool isPaused);
    }
}