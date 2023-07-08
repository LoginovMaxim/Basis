using System.Threading;
using System.Threading.Tasks;

namespace Basis.Configs
{
    public interface IResourceProvider
    {
        Task<TObject> LoadResourceAsync<TObject>(string path, CancellationToken token) where TObject : UnityEngine.Object;
        Task<UnityEngine.Object> LoadResourceAsync(string path, CancellationToken token);
    }
}