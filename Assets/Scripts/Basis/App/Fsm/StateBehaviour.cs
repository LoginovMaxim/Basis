using System;
using System.Collections.Generic;

namespace Basis.App.Fsm
{
    public abstract class StateBehaviour<TStateType> : IStateBehaviour<TStateType> where TStateType : Enum
    {
        public abstract void OnEnter();

        public abstract void OnUpdate();

        public abstract void OnExit();

        public abstract List<ITransition<TStateType>> GetTransitions();
    }
}