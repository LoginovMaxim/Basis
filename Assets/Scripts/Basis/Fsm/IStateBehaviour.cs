using System;
using System.Collections.Generic;

namespace Basis.Fsm
{
    public interface IStateBehaviour<TStateType>
    {
        void OnEnter();
        void OnUpdate();
        void OnExit();    
        List<ITransition<TStateType>> GetTransitions();
        List<Func<bool>> GetBlockingConditions();
    }
}