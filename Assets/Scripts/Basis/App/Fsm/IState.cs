using System;

namespace Basis.App.Fsm
{
    public interface IState
    {
        ValueType StateCode { get; }
        
        void OnEnter();
        void OnUpdate();
        void OnExit();
        bool TrySwitchOtherState(out ValueType otherStateCode);
    }
}