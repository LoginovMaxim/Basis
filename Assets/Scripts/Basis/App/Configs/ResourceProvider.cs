using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Basis.App.Configs
{
    public sealed class ResourceProvider : IResourceProvider
    {
        public async Task<TObject> LoadResourceAsync<TObject>(string path, CancellationToken token) where TObject : Object
        {
            var resource = (TObject) await Resources.LoadAsync<TObject>(path);
            token.ThrowIfCancellationRequested();
            return resource;
        }

        public async Task<Object> LoadResourceAsync(string path, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<Object>(path);
            token.ThrowIfCancellationRequested();
            return resource;
        }
    }
}