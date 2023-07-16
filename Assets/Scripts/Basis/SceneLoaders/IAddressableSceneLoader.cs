using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Basis.SceneLoaders
{
    public interface IAddressableSceneLoader
    {
        UniTask<AsyncOperationHandle<SceneInstance>> LoadSceneAsync(string scenePath, LoadSceneMode loadSceneMode, bool isActiveScene, bool autoUnload);
        UniTask UnloadSceneAsync(string scenePath);
        UniTask UnloadSceneAsync(AsyncOperationHandle<SceneInstance> asyncOperationHandle);
    }
}