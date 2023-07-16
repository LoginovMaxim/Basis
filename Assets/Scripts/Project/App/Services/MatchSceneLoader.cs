using System.Threading;
using Basis.SceneLoaders;
using Basis.Services;
using Basis.UI.Splashes;
using Cysharp.Threading.Tasks;
using Project.App.Data;
using UnityEngine.SceneManagement;

namespace Project.App.Services
{
    public sealed class MatchSceneLoader : AsyncLoader, IMatchSceneLoader
    {
        private readonly IProfileProvider _profileProvider;
        private readonly ISceneLoader _sceneLoader;
        private readonly ISplash _splash;

        public MatchSceneLoader(
            IProfileProvider profileProvider, 
            ISceneLoader sceneLoader,
            ISplash splash)
        {
            _profileProvider = profileProvider;
            _sceneLoader = sceneLoader;
            _splash = splash;
        }

        public override async UniTask LoadAsync(CancellationToken token)
        {
            _splash.Show();
            
            await _sceneLoader.LoadSceneAsync(
                string.Format(Constants.LevelBundleKeys.LevelSceneKeyFormat, _profileProvider.Level), 
                LoadSceneMode.Single, 
                true,
                token);
            
            await _sceneLoader.LoadSceneAsync(
                Constants.MatchBundleKeys.MatchSceneKey, 
                LoadSceneMode.Additive, 
                true,
                token);
        }
    }
}