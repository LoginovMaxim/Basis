using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Basis.SceneLoaders
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask LoadSceneAsync(string scenePath, LoadSceneMode loadSceneMode, bool isActiveScene, CancellationToken token)
        {
            var sceneName = scenePath.Split('/');
            var asyncOperation = SceneManager.LoadSceneAsync(scenePath, loadSceneMode);
            asyncOperation.allowSceneActivation = false;
            
            if (isActiveScene)
            {
                asyncOperation.completed += operation =>
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName[sceneName.Length - 1]));
                };
            }

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                
                if (asyncOperation.progress >= 0.9f)
                {
                    break;
                }

                await UniTask.Yield();
            }

            asyncOperation.allowSceneActivation = true;
        }

        public async UniTask UnloadSceneAsync(string scenePath, CancellationToken token)
        {
            var asyncOperation = SceneManager.UnloadSceneAsync(scenePath);
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                
                if (asyncOperation.progress >= 0.9f)
                {
                    break;
                }

                await UniTask.Yield();
            }
        }
    }
}