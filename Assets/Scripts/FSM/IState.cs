using System;

namespace FSM
{
    public interface IState
    {
        string StateCode { get; }

        IState SetEnterAction(Action action);
        IState SetUpdateAction(Action action);
        IState SetExitAction(Action action);

        bool TrySwitchOtherState(out string otherStateCode);
        
        void OnEnter();
        void OnUpdate();
        void OnExit();
    }
}