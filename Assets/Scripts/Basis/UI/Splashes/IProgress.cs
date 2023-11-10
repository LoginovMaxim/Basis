using System;

namespace Basis.UI.Splashes
{
    public interface IProgress
    {
        event Action<float> OnProgressChanged;
        float Progress { get; }
    }
}