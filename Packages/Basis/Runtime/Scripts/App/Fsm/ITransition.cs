namespace App.Fsm
{
    public interface ITransition
    {
        string TransitionStateCode { get; }
        bool IsTransition();
    }
}