using System.Threading;
using System.Threading.Tasks;

namespace Basis.App.Configs
{
    public interface IResourceProvider
    {
        Task<TObject> LoadResource<TObject>(string path, CancellationToken token) where TObject : UnityEngine.Object;
        Task<UnityEngine.Object> LoadResource(string path, CancellationToken token);
    }
}