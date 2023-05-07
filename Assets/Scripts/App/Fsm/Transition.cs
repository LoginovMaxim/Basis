using System;

namespace App.Fsm
{
    public class Transition : ITransition
    {
        private readonly ValueType _transitionStateCode;
        private readonly Func<bool> _func;
        
        public Transition(ValueType transitionStateCode, Func<bool> func)
        {
            _transitionStateCode = transitionStateCode;
            _func = func;
        }

        public bool IsTransition() => _func.Invoke();

        #region ITransition
        
        ValueType ITransition.TransitionStateCode => _transitionStateCode;

        #endregion
    }
}