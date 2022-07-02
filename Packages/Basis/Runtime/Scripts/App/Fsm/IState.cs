using System;
using System.Collections.Generic;

namespace App.Fsm
{
    public interface IState
    {
        string StateCode { get; }

        void SetEnter(Action action);
        void SetUpdate(Action action);
        void SetExit(Action action);
        void SetTransitions(List<ITransition> transitions);

        bool TrySwitchOtherState(out string otherStateCode);
        
        void OnEnter();
        void OnUpdate();
        void OnExit();
    }
}