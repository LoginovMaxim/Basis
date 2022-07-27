using System;

namespace App.Fsm
{
    public interface ITransition
    {
        ValueType TransitionStateCode { get; }
        bool IsTransition();
    }
}