using System;

namespace App.Fsm
{
    public interface IStateMachine
    {
        void Start();
        void AddState(IState state);
        void SetInitialState(ValueType stateCode);
    }
}