using System;
using System.Collections.Generic;
using App.Monos;
using Zenject;

namespace App.Fsm
{
    public class StateMachine : IStateMachine, IDisposable
    {
        private readonly IMonoUpdater _monoUpdater;
        
        private Dictionary<ValueType, State> _states = new();
        private State _currentState;
        
        public StateMachine(IMonoUpdater monoUpdater)
        {
            _monoUpdater = monoUpdater;
            _monoUpdater.Subscribe(UpdateType.Update, OnUpdate);
        }

        private void AddState(State state)
        {
            _states.Add(state.StateCode, state);
        }

        private void SetInitialState(ValueType stateCode)
        {
            SwitchState(stateCode);
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
        
        private void OnUpdate()
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
        
        protected virtual void Dispose()
        {
            _monoUpdater.Unsubscribe(UpdateType.Update, OnUpdate);
        }

        #region IStateMachine

        void IStateMachine.AddState(State state)
        {
            AddState(state);
        }

        void IStateMachine.SetInitialState(ValueType stateCode)
        {
            SetInitialState(stateCode);
        }

        #endregion

        #region IDisposable
        
        void IDisposable.Dispose()
        {
            Dispose();
        }

        #endregion

        public class Factory : PlaceholderFactory<StateMachine> { }
    }
}