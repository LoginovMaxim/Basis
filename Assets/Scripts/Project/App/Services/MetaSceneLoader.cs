using System.Threading;
using BasisCore.Runtime.SceneLoaders;
using Cysharp.Threading.Tasks;
using Project.App.Data;
using UnityEngine.SceneManagement;

namespace Project.App.Services
{
    public sealed class MetaSceneLoader : IMetaSceneLoader
    {
        private readonly ISceneLoader _sceneLoader;

        public MetaSceneLoader(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async UniTask LoadAsync(CancellationToken token)
        {
            await _sceneLoader.LoadSceneAsync(
                Constants.MetaBundleKeys.MetaSceneKey, 
                LoadSceneMode.Single, 
                true,
                token);
        }

        public async UniTask UnloadAsync(CancellationToken token)
        {
            await _sceneLoader.UnloadSceneAsync(Constants.MetaBundleKeys.MetaSceneKey, token);
        }
    }
}