﻿namespace Basis.App.Services
{
    public interface IUpdatableService : IService
    {
        bool IsPaused { get; }
        
        void Pause();
        void Unpause();
    }
}