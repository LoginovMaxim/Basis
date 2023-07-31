namespace Basis.Services
{
    public interface IUpdatableService
    {
        bool IsPaused { get; }

        void Start();
        void Pause();
        void Unpause();
    }
}