namespace FSM
{
    public interface IStateMachine
    {
        //Dictionary<string, State> States { get; }
        //State CurrentState { get; }

        void AddState(State state);
        void SetInitialState(string stateCode);
    }
}