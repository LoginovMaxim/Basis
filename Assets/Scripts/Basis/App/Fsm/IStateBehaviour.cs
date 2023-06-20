using System.Collections.Generic;

namespace Basis.App.Fsm
{
    public interface IStateBehaviour
    {
        void OnEnter();
        void OnUpdate();
        void OnExit();    
        List<ITransition> GetTransitions();
    }
}