using System;

namespace FSM
{
    public class Transition : ITransition
    {
        public string TransitionStateCode => _transitionStateCode;
        
        private string _transitionStateCode;

        private Func<bool> _func;
        
        public Transition(string transitionStateCode, Func<bool> func)
        {
            _transitionStateCode = transitionStateCode;
            _func = func;
        }

        public bool IsTransition() => _func.Invoke();
    }
}