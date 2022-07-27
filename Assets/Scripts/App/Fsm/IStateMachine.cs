using System;

namespace App.Fsm
{
    public interface IStateMachine
    {
        void AddState(State state);
        void SetInitialState(ValueType stateCode);
    }
}