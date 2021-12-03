namespace FSM
{
    public interface ITransition
    {
        string TransitionStateCode { get; }
        bool IsTransition();
    }
}