namespace Basis.Services
{
    public interface IUpdatableService : IService
    {
        bool IsPaused { get; }

        void Start();
        void Pause();
        void Unpause();
    }
}