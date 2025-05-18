using UniRx;

namespace Basis.Core.UI
{
    public sealed class LoadingSplashModel
    {
        public readonly ReactiveProperty<float> Progress = new();
    }
}