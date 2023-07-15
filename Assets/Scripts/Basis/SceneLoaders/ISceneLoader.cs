using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Basis.SceneLoaders
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(string scenePath, bool isActiveScene, LoadSceneMode loadSceneMode, CancellationToken token);
        UniTask UnloadSceneAsync(string scenePath, CancellationToken token);
    }
}