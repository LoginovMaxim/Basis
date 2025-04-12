using System.Threading;
using Basis.Core.Storage;
using BasisCore.SceneLoaders;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Basis.Core.Services
{
    public sealed class MatchSceneLoader : IMatchSceneLoader
    {
        private readonly IProfileProvider _profileProvider;
        private readonly ISceneLoader _sceneLoader;

        public MatchSceneLoader(
            IProfileProvider profileProvider, 
            ISceneLoader sceneLoader)
        {
            _profileProvider = profileProvider;
            _sceneLoader = sceneLoader;
        }

        public async UniTask LoadAsync(CancellationToken token)
        {
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
            await _sceneLoader.UnloadSceneAsync(Constants.MatchBundleKeys.MatchSceneKey, token);
            await _sceneLoader.UnloadSceneAsync(
                string.Format(Constants.LevelBundleKeys.LevelSceneKeyFormat, _profileProvider.ProgressData.Level), 
                token);
        }
    }
}