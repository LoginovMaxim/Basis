using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Basis.SceneLoaders
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(string scenePath, LoadSceneMode loadSceneMode, bool isActiveScene, CancellationToken token);
        UniTask UnloadSceneAsync(string scenePath, CancellationToken token);
    }
}