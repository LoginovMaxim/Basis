using System.Collections.Generic;

namespace App.Fsm
{
    public abstract class StateBehaviour
    {
        protected IState _state;

        protected StateBehaviour(IState state)
        {
            _state = state;
            _state.SetEnter(OnEnter);
            _state.SetUpdate(OnUpdate);
            _state.SetExit(OnExit);
            _state.SetTransitions(GetTransitions());
        }

        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();    
        public abstract List<ITransition> GetTransitions();
    }
}