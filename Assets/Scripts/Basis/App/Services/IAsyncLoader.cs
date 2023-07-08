using System.Threading;
using Cysharp.Threading.Tasks;

namespace Basis.App.Services
{
    public interface IAsyncLoader
    {
        public UniTask LoadAsync(CancellationToken token);
    }
}