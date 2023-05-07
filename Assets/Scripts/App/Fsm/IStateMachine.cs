using App.Services;

namespace App.Fsm
{
    public interface IStateMachine : IUpdatableService
    {
        void Start();
    }
}