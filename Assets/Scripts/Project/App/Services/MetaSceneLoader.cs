using System.Threading;
using BasisCore.Runtime.SceneLoaders;
using BasisCore.Runtime.UI.LoadingSplash;
using Cysharp.Threading.Tasks;
using Project.App.Data;
using Project.Meta.UI;
using UnityEngine.SceneManagement;

namespace Project.App.Services
{
    public sealed class MetaSceneLoader : IMetaSceneLoader
    {
        private readonly IMetaScreenService _metaScreenService;
        private readonly ISceneLoader _sceneLoader;
        private readonly LoadingSplashWindowController _loadingSplashWindowController;

        public MetaSceneLoader(ISceneLoader sceneLoader, LoadingSplashWindowController loadingSplashWindowController)
        {
            _sceneLoader = sceneLoader;
            _loadingSplashWindowController = loadingSplashWindowController;
        }

        public async UniTask LoadAsync(CancellationToken token)
        {
            _loadingSplashWindowController.Show();
            
            await _sceneLoader.LoadSceneAsync(
                Constants.MetaBundleKeys.MetaSceneKey, 
                LoadSceneMode.Single, 
                true,
                token);
        }

        public async UniTask UnloadAsync(CancellationToken token)
        {
            _loadingSplashWindowController.Show();
            
            await _sceneLoader.UnloadSceneAsync(Constants.MetaBundleKeys.MetaSceneKey, token);
        }
    }
}