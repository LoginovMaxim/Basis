using Basis.App.Services;

namespace Basis.App.Fsm
{
    public interface IStateMachine : IUpdatableService
    {
        void Start();
    }
}