namespace Services
{
    public interface IService
    {
        bool IsPaused { get; }
        
        void Start();
        void Pause(bool isPaused);
    }
}