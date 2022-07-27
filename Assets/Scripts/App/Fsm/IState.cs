using System;
using System.Collections.Generic;

namespace App.Fsm
{
    public interface IState
    {
        ValueType StateCode { get; }

        IState SetEnter(Action action);
        IState SetUpdate(Action action);
        IState SetExit(Action action);
        void SetTransitions(List<ITransition> transitions);

        bool TrySwitchOtherState(out ValueType otherStateCode);
        
        void OnEnter();
        void OnUpdate();
        void OnExit();
    }
}