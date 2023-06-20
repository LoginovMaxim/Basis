using System;

namespace Basis.App.Fsm
{
    public interface ITransition
    {
        ValueType TransitionStateCode { get; }
        bool IsTransition();
    }
}