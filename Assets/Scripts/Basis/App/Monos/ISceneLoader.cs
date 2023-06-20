using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Basis.App.Monos
{
    public interface ISceneLoader
    {
        void LoadScene(string scenePath, LoadSceneMode loadSceneMode, Action onComplete);
        void UnloadScene(string scenePath);
        Task LoadSceneAsync(string scenePath, bool isActiveScene, LoadSceneMode loadSceneMode);
        Task UnloadAdditiveSceneAsync(string scenePath);
    }
}