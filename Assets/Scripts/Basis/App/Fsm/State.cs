using System;
using System.Collections.Generic;

namespace Basis.App.Fsm
{
    public class State : IState
    {
        private readonly ValueType _stateCode;
        private readonly IStateBehaviour _stateBehaviour;
        private readonly List<ITransition> _transitions;

        private State(ValueType stateCode, IStateBehaviour stateBehaviour)
        {
            _stateCode = stateCode;
            _stateBehaviour = stateBehaviour;
            _transitions = stateBehaviour.GetTransitions();
        }

        public static IState NewInstance(ValueType stateCode, IStateBehaviour stateBehaviour)
        {
            return new State(stateCode, stateBehaviour);
        }

        public void OnEnter()
        {
            _stateBehaviour.OnEnter();
        }

        public void OnUpdate()
        {
            _stateBehaviour.OnUpdate();
        }

        public void OnExit()
        {
            _stateBehaviour.OnExit();
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

        #region IState
        
        ValueType IState.StateCode => _stateCode;

        #endregion
    }
}