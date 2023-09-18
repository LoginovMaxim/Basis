using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Basis.ResourceProviders
{
    public interface IResourceProvider
    {
        UniTask<TObject> LoadResourceAsync<TObject>(string path, CancellationToken token) where TObject : Object;
        void UnloadResource(string resourceId);
    }
}