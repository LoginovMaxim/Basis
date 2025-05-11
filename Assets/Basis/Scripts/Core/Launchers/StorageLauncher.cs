using System.Collections.Generic;
using System.Threading;
using BasisCore.Launchers;
using BasisCore.Storage;
using Cysharp.Threading.Tasks;

namespace Basis.Core.Launchers
{
    public sealed class StorageLauncher : ILauncher
    {
        private readonly List<IStorageItemProvider> _storageItemProviders;

        public StorageLauncher(List<IStorageItemProvider> storageItemProviders)
        {
            _storageItemProviders = storageItemProviders;
        }

        public async UniTask LaunchAsync(CancellationToken token)
        {
            var uniTasks = _storageItemProviders.ConvertAll(provider => provider.LoadStorageItemAsync());
            await UniTask.WhenAll(uniTasks);
        }
    }
}