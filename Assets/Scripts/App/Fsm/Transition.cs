using System;

namespace App.Fsm
{
    public class Transition : ITransition
    {
        public ValueType TransitionStateCode => _transitionStateCode;
        
        private ValueType _transitionStateCode;

        private Func<bool> _func;
        
        public Transition(ValueType transitionStateCode, Func<bool> func)
        {
            _transitionStateCode = transitionStateCode;
            _func = func;
        }

        public bool IsTransition() => _func.Invoke();
    }
}