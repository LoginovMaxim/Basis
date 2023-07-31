using System.Threading;
using Cysharp.Threading.Tasks;

namespace Basis.Services
{
    public interface IAsyncLoader
    {
        public UniTask LoadAsync(CancellationToken token);
        public UniTask UnloadAsync(CancellationToken token);
    }
}