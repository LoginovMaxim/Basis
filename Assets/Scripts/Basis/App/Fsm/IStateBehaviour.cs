using System.Collections.Generic;

namespace Basis.App.Fsm
{
    public interface IStateBehaviour<TStateType>
    {
        void OnEnter();
        void OnUpdate();
        void OnExit();    
        List<ITransition<TStateType>> GetTransitions();
    }
}