﻿using Basis.Services;

namespace Basis.Fsm
{
    public interface IStateMachine<TStateType> : IUpdatableService
    {
        void Start();
        void Update();
        void AddState(TStateType valueType, IStateBehaviour<TStateType> stateBehaviour);
        void RemoveState(TStateType stateType);
    }
}