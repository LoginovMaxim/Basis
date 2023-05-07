using System.Collections.Generic;

namespace App.Fsm
{
    public interface IStateBehaviour
    {
        void OnEnter();
        void OnUpdate();
        void OnExit();    
        List<ITransition> GetTransitions();
    }
}