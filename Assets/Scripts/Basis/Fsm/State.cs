using System;
using System.Collections.Generic;

namespace Basis.Fsm
{
    public class State<TStateType> : IState<TStateType> where TStateType : Enum
    {
        public TStateType StateType => _stateCode;
        
        private readonly TStateType _stateCode;
        private readonly IStateBehaviour<TStateType> _stateBehaviour;
        private readonly List<ITransition<TStateType>> _transitions;
        private readonly List<Func<bool>> _blockingConditions;
        
        public State(TStateType stateCode, IStateBehaviour<TStateType> stateBehaviour)
        {
            _stateCode = stateCode;
            _stateBehaviour = stateBehaviour;
            _transitions = stateBehaviour.GetTransitions();
            _blockingConditions = stateBehaviour.GetBlockingConditions();
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

        public bool TrySwitchOtherState(out TStateType otherStateCode)
        {
            otherStateCode = default;
            
            foreach (var blockingCondition in _blockingConditions)
            {
                if (!blockingCondition.Invoke())
                {
                    return false;
                }
            }
            
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
    }
}