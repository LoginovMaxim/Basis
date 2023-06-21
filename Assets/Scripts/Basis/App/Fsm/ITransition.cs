namespace Basis.App.Fsm
{
    public interface ITransition<TStateType>
    {
        TStateType TransitionStateCode { get; }
        bool IsTransition();
    }
}