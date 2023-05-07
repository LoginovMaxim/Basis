using System;
using System.Collections.Generic;
using App.Monos;
using App.Services;
using Zenject;

namespace App.Fsm
{
    public class StateMachine : UpdatableService, IStateMachine
    {
        private readonly Dictionary<ValueType, IState> _states = new();
        
        private IState _currentState;
        private ValueType _initialStateCode;

        public StateMachine(IMonoUpdater monoUpdater) : base(monoUpdater, UpdateType.Update, false)
        {
        }

        protected override void Start()
        {
            SwitchState(_initialStateCode);
            base.Start();
        }

        private void AddState(IState state)
        {
            _states.Add(state.StateCode, state);
        }

        private void SetInitialState(ValueType stateCode)
        {
            _initialStateCode = stateCode;
        }

        private void SwitchState(ValueType stateCode)
        {
            if (!_states.ContainsKey(stateCode))
            {
                return;
            }
            
            _currentState?.OnExit();
            _currentState = _states[stateCode];
            _currentState?.OnEnter();
        }

        protected override void Update()
        {
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

        #region IStateMachine

        void IStateMachine.Start()
        {
            Start();
        }

        void IStateMachine.AddState(IState state)
        {
            AddState(state);
        }

        void IStateMachine.SetInitialState(ValueType stateCode)
        {
            SetInitialState(stateCode);
        }

        #endregion

        public class Factory : PlaceholderFactory<StateMachine> { }
    }
}