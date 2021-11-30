using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monos
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScenes(string sceneName)
        {
            StartCoroutine(LoadingScenes(sceneName));
        }
        
        private IEnumerator LoadingScenes(string sceneName)
        {
            var loadSceneAsync = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            loadSceneAsync.allowSceneActivation = false;

            while(!loadSceneAsync.isDone)
            {
                yield return null;
            }
            
            loadSceneAsync.allowSceneActivation = true;
            yield return null;
        }
    }
}