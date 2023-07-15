using System.Threading;
using System.Threading.Tasks;

namespace Basis.ResourceProviders
{
    public interface IResourceProvider
    {
        Task<TObject> LoadResourceAsync<TObject>(string path, CancellationToken token) where TObject : UnityEngine.Object;
    }
}