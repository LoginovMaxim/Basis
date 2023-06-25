using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Basis.App.Monos
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        public void LoadScene(string sceneName, LoadSceneMode loadSceneMode, Action onComplete)
        {
            StartCoroutine(LoadingScene(sceneName, loadSceneMode, onComplete));
        }

        public void UnloadScene(string sceneName)
        {
            StartCoroutine(UnloadingScene(sceneName));
        }

        public async UniTask LoadSceneAsync(string scenePath, bool isActiveScene, LoadSceneMode loadSceneMode)
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
                if (asyncOperation.progress >= 0.9f)
                {
                    break;
                }

                await UniTask.Yield();
            }

            asyncOperation.allowSceneActivation = true;
        }

        public async UniTask UnloadAdditiveSceneAsync(string scenePath)
        {
            var asyncOperation = SceneManager.UnloadSceneAsync(scenePath);
            while (true)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    break;
                }

                await UniTask.Yield();
            }
        }

        private IEnumerator LoadingScene(string scenePath, LoadSceneMode loadSceneMode, Action onComplete)
        {
            var sceneName = scenePath.Split('/');
            var asyncOperation = SceneManager.LoadSceneAsync(scenePath, loadSceneMode);
            asyncOperation.completed += _ =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName[sceneName.Length - 1]));
                onComplete?.Invoke();
            };
            
            asyncOperation.allowSceneActivation = false;
            while (true)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    break;
                }
                
                yield return null;
            }

            asyncOperation.allowSceneActivation = true;
        }

        private IEnumerator UnloadingScene(string scenePath)
        {
            var asyncOperation = SceneManager.UnloadSceneAsync(scenePath);
            while (!asyncOperation.isDone)
            {
                yield return null;
            }
            
            asyncOperation.allowSceneActivation = false;
        }
    }
}