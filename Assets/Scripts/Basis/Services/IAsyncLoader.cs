using System.Threading;
using Cysharp.Threading.Tasks;

namespace Basis.Services
{
    public interface IAsyncLoader
    {
        public UniTask LoadAsync(CancellationToken token);
        public void Load();
    }
}