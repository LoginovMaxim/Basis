using System;
using System.Collections.Generic;
using Monos;
using Zenject;

namespace FSM
{
    public class StateMachine : IStateMachine, IDisposable
    {
        private readonly MonoUpdater _monoUpdater;
        
        private Dictionary<string, State> _states;
        private State _currentState;

        private UpdateType _updateType;
        
        public StateMachine(UpdateType updateType, MonoUpdater monoUpdater)
        {
            _updateType = updateType;
            _monoUpdater = monoUpdater;
            _monoUpdater.Subscribe(_updateType, OnUpdate);
            
            _states = new Dictionary<string, State>();
        }

        public void AddState(State state)
        {
            _states.Add(state.StateCode, state);
        }

        public void SetInitialState(string stateCode)
        {
            SwitchState(stateCode);
        }

        private void SwitchState(string stateCode)
        {
            if (!_states.ContainsKey(stateCode))
                return;
            
            _currentState?.OnExit();
            _currentState = _states[stateCode];
            _currentState?.OnEnter();
        }
        
        private void OnUpdate()
        {
            if (_currentState == null)
                return;
            
            _currentState.OnUpdate();
            
            if (!_currentState.TrySwitchOtherState(out var otherStateCode))
                return;
            
            SwitchState(otherStateCode);
        }

        public virtual void Dispose()
        {
            _monoUpdater.Unsubscribe(_updateType, OnUpdate);
        }

        public class Factory : PlaceholderFactory<UpdateType, StateMachine> { }
    }
}