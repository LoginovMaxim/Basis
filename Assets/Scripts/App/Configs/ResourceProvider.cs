using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Configs
{
    public sealed class ResourceProvider : IResourceProvider
    {
        private async Task<TObject> LoadResourceAsyc<TObject>(string path, CancellationToken token) where TObject : Object
        {
            var resource = (TObject) await Resources.LoadAsync<TObject>(path);
            token.ThrowIfCancellationRequested();
            return resource;
        }

        private async Task<Object> LoadResourceAsyc(string path, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<Object>(path);
            token.ThrowIfCancellationRequested();
            return resource;
        }

        #region IResourceProvider

        Task<Object> IResourceProvider.LoadResource(string path, CancellationToken token)
        {
            return LoadResourceAsyc(path, token);
        }

        Task<TObject> IResourceProvider.LoadResource<TObject>(string path, CancellationToken token)
        {
            return LoadResourceAsyc<TObject>(path, token);
        }

        #endregion
    }
}