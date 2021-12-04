namespace FSM
{
    public interface IStateMachine
    {
        void AddState(State state);
        void SetInitialState(string stateCode);
    }
}