using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace App.Monos
{
    public interface ISceneLoader
    {
        void LoadScene(string scenePath, LoadSceneMode loadSceneMode, Action onComplete);
        void UnloadScene(string scenePath, Action onComplete);
        Task LoadSceneAsync(string scenePath, bool isActiveScene, LoadSceneMode loadSceneMode);
        Task UnloadAdditiveSceneAsync(string scenePath);
    }
}