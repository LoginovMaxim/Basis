using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Basis.App.Monos
{
    public interface ISceneLoader
    {
        void LoadScene(string scenePath, LoadSceneMode loadSceneMode, Action onComplete);
        void UnloadScene(string scenePath);
        UniTask LoadSceneAsync(string scenePath, bool isActiveScene, LoadSceneMode loadSceneMode);
        UniTask UnloadAdditiveSceneAsync(string scenePath);
    }
}