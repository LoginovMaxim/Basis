using BasisCore.UI;
using UniRx;

namespace Basis.Core.UI
{
    public interface ILoadingSplashWindowViewModel : IWindowViewModel
    {
        ReactiveProperty<float> Progress { get; }
    }
}