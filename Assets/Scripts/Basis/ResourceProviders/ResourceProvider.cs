using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Basis.ResourceProviders
{
    public sealed class ResourceProvider : IResourceProvider
    {
        public async UniTask<TObject> LoadResourceAsync<TObject>(string path, CancellationToken token) where TObject : Object
        {
            var resource = (TObject) await Resources.LoadAsync<TObject>(path);
            token.ThrowIfCancellationRequested();
            return resource;
        }

        public void UnloadResource(string resourceId)
        {
        }
    }
}