using System;
using System.Collections.Generic;

namespace App.Fsm
{
    public class State : IState
    {
        public ValueType StateCode => _stateCode;

        private ValueType _stateCode;
        
        private Action _enterAction;
        private Action _updateAction;
        private Action _exitAction;

        private List<ITransition> _transitions;
        
        public State(ValueType stateCode)
        {
            _stateCode = stateCode;
        }
        
        public IState SetEnter(Action enterAction)
        {
            _enterAction = enterAction;
            return this;
        }

        public IState SetUpdate(Action updateAction)
        {
            _updateAction = updateAction;
            return this;
        }

        public IState SetExit(Action exitAction)
        {
            _exitAction = exitAction;
            return this;
        }

        public void SetTransitions(List<ITransition> transitions)
        {
            _transitions = transitions;
        }

        public bool TrySwitchOtherState(out ValueType otherStateCode)
        {
            otherStateCode = default;
            foreach (var transition in _transitions)
            {
                if (!transition.IsTransition())
                    continue;

                otherStateCode = transition.TransitionStateCode;
                return true;
            }

            return false;
        }

        public void OnEnter()
        {
            _enterAction?.Invoke();
        }

        public void OnUpdate()
        {
            _updateAction?.Invoke();
        }

        public void OnExit()
        {
            _exitAction?.Invoke();
        }
    }
}