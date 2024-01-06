using System.Threading;
using BasisCore.Runtime.SceneLoaders;
using BasisCore.Runtime.UI.LoadingSplash;
using Cysharp.Threading.Tasks;
using Project.App.Data;
using UnityEngine.SceneManagement;

namespace Project.App.Services
{
    public sealed class MatchSceneLoader : IMatchSceneLoader
    {
        private readonly IProfileProvider _profileProvider;
        private readonly ISceneLoader _sceneLoader;
        private readonly LoadingSplashWindowController _loadingSplashWindowController;

        public MatchSceneLoader(
            IProfileProvider profileProvider, 
            ISceneLoader sceneLoader,
            LoadingSplashWindowController loadingSplashWindowController)
        {
            _profileProvider = profileProvider;
            _sceneLoader = sceneLoader;
            _loadingSplashWindowController = loadingSplashWindowController;
        }

        public async UniTask LoadAsync(CancellationToken token)
        {
            _loadingSplashWindowController.Show();
            
            await _sceneLoader.LoadSceneAsync(
                string.Format(Constants.LevelBundleKeys.LevelSceneKeyFormat, _profileProvider.ProgressData.Level), 
                LoadSceneMode.Single, 
                true,
                token);
            
            await _sceneLoader.LoadSceneAsync(
                Constants.MatchBundleKeys.MatchSceneKey, 
                LoadSceneMode.Additive, 
                true,
                token);
        }

        public async UniTask UnloadAsync(CancellationToken token)
        {
            _loadingSplashWindowController.Show();
            
            await _sceneLoader.UnloadSceneAsync(Constants.MatchBundleKeys.MatchSceneKey, token);
            await _sceneLoader.UnloadSceneAsync(
                string.Format(Constants.LevelBundleKeys.LevelSceneKeyFormat, _profileProvider.ProgressData.Level), 
                token);
        }
    }
}