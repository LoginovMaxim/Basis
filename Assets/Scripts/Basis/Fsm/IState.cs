namespace Basis.Fsm
{
    public interface IState<TStateType>
    {
        TStateType StateType { get; }
        
        void OnEnter();
        void OnUpdate();
        void OnExit();
        bool TrySwitchOtherState(out TStateType otherStateCode);
    }
}