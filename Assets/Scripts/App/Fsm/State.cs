using System;
using System.Collections.Generic;

namespace App.Fsm
{
    public class State : IState
    {
        private readonly ValueType _stateCode;
        private readonly Action _enterAction;
        private readonly Action _updateAction;
        private readonly Action _exitAction;
        private readonly List<ITransition> _transitions;

        private State(ValueType stateCode, IStateBehaviour stateBehaviour)
        {
            _stateCode = stateCode;
            _enterAction = stateBehaviour.OnEnter;
            _updateAction = stateBehaviour.OnUpdate;
            _exitAction = stateBehaviour.OnExit;
            _transitions = stateBehaviour.GetTransitions();
        }

        public static IState NewInstance(ValueType stateCode, IStateBehaviour stateBehaviour)
        {
            return new State(stateCode, stateBehaviour);
        }

        public bool TrySwitchOtherState(out ValueType otherStateCode)
        {
            otherStateCode = default;
            foreach (var transition in _transitions)
            {
                if (!transition.IsTransition())
                {
                    continue;
                }

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

        #region IState
        
        ValueType IState.StateCode => _stateCode;

        #endregion
    }
}