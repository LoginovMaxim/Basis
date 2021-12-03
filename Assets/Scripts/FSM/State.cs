using System;
using System.Collections.Generic;

namespace FSM
{
    public class State : IState
    {
        public string StateCode => _stateCode;

        private string _stateCode;
        
        private Action _enterAction;
        private Action _updateAction;
        private Action _exitAction;

        private List<ITransition> _transitions;
        
        public State(string stateCode, List<ITransition> transitions)
        {
            _stateCode = stateCode;
            _transitions = transitions;
        }
        
        public IState SetEnterAction(Action enterAction)
        {
            _enterAction = enterAction;
            return this;
        }

        public IState SetUpdateAction(Action updateAction)
        {
            _updateAction = updateAction;
            return this;
        }

        public IState SetExitAction(Action exitAction)
        {
            _exitAction = exitAction;
            return this;
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