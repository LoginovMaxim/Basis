using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Basis.ResourceProviders
{
    public interface IResourceProvider
    {
        UniTask<TObject> LoadResourceAsync<TObject>(string path, CancellationToken token) where TObject : Object;
        void UnloadResource<TObject>(TObject resourceObject) where TObject : UnityEngine.Object;
        void UnloadResource(string resourceId);
    }
}