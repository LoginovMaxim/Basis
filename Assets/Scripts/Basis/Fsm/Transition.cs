using System;

namespace Basis.Fsm
{
    public class Transition<TStateType> : ITransition<TStateType> where TStateType : Enum
    {
        public TStateType TransitionStateCode => _transitionStateCode;
        
        private readonly TStateType _transitionStateCode;
        private readonly Func<bool> _func;
        
        public Transition(TStateType transitionStateCode, Func<bool> func)
        {
            _transitionStateCode = transitionStateCode;
            _func = func;
        }

        public bool IsTransition() => _func.Invoke();
    }
}