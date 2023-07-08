using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Basis.App.Monos
{
    public interface ISceneLoader
    {
        void LoadScene(string scenePath, LoadSceneMode loadSceneMode, Action onComplete);
        void UnloadScene(string scenePath);
        UniTask LoadSceneAsync(string scenePath, bool isActiveScene, LoadSceneMode loadSceneMode, CancellationToken token);
        UniTask UnloadAdditiveSceneAsync(string scenePath, CancellationToken token);
    }
}