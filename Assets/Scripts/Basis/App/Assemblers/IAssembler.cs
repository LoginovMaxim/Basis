using System;

namespace Basis.App.Assemblers
{
    public interface IAssembler
    {
        public event Action<float> OnStepLoaded;
        int ServicesCount { get; }
        int CurrentStepCount { get; }
        float Progress { get; }
    }
}