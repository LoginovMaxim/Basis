using System;
using System.Collections.Generic;

namespace App.Fsm
{
    public class State : IState
    {
        public string StateCode => _stateCode;

        private string _stateCode;
        
        private Action _enterAction;
        private Action _updateAction;
        private Action _exitAction;

        private List<ITransition> _transitions;
        
        public State(string stateCode)
        {
            _stateCode = stateCode;
        }
        
        public void SetEnter(Action enterAction)
        {
            _enterAction = enterAction;
        }

        public void SetUpdate(Action updateAction)
        {
            _updateAction = updateAction;
        }

        public void SetExit(Action exitAction)
        {
            _exitAction = exitAction;
        }

        public void SetTransitions(List<ITransition> transitions)
        {
            _transitions = transitions;
        }

        public bool TrySwitchOtherState(out string otherStateCode)
        {
            otherStateCode = string.Empty;
            
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