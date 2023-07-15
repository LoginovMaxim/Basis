using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Basis.Services
{
    public abstract class AsyncLoader : IAsyncLoader, IDisposable
    {
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        public abstract UniTask LoadAsync(CancellationToken token);

        public virtual async void Load()
        {
            _tokenSource = new CancellationTokenSource();
            await LoadAsync(_tokenSource.Token);
        }

        public virtual void Dispose()
        {
            _tokenSource.Cancel();
        }
    }
}