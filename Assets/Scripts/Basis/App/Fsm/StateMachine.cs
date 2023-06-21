using System;
using System.Collections.Generic;

namespace Basis.App.Fsm
{
    public abstract class StateMachine<TStateType> : IStateMachine<TStateType> where TStateType : Enum
    {
        public bool IsPaused { get; private set; }
        
        private readonly Dictionary<TStateType, IState<TStateType>> _states = new();
            
        private IState<TStateType> _currentState;
        private TStateType _initialStateCode;

        public void Start()
        {
            SwitchState(_initialStateCode);
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Unpause()
        {
            IsPaused = false;
        }

        public void AddState(TStateType valueType, IStateBehaviour<TStateType> stateBehaviour)
        {
            var state = State<TStateType>.NewInstance(valueType, stateBehaviour);
            if (_states.ContainsKey(state.StateType))
            {
                return;
            }
            
            _states.Add(state.StateType, state);
        }

        public void RemoveState(TStateType stateType)
        {
            if (!_states.ContainsKey(stateType))
            {
                return;
            }

            _states.Remove(stateType);
        }

        protected void SetInitialState(TStateType stateCode)
        {
            _initialStateCode = stateCode;
        }

        private void SwitchState(TStateType stateCode)
        {
            if (!_states.ContainsKey(stateCode))
            {
                return;
            }
                
            _currentState?.OnExit();
            _currentState = _states[stateCode];
            _currentState?.OnEnter();
        }

        public void Update()
        {
            if (IsPaused)
            {
                return;
            }
            
            if (_currentState == null)
            {
                return;
            }
                
            _currentState.OnUpdate();
                
            if (!_currentState.TrySwitchOtherState(out var otherStateCode))
            {
                return;
            }
                
            SwitchState(otherStateCode);
        }
    }
}