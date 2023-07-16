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
        private readonly IAddressableSceneLoader _addressableSceneLoader;
        private readonly ISplash _splash;

        public MatchSceneLoader(
            IProfileProvider profileProvider, 
            IAddressableSceneLoader addressableSceneLoader, 
            ISplash splash)
        {
            _profileProvider = profileProvider;
            _addressableSceneLoader = addressableSceneLoader;
            _splash = splash;
        }

        public override async UniTask LoadAsync(CancellationToken token)
        {
            await _splash.Show();

            await _addressableSceneLoader.LoadSceneAsync(
                string.Format(Constants.LevelBundleKeys.LevelSceneKey, _profileProvider.Level), 
                LoadSceneMode.Single, 
                true,
                true);
            
            await _addressableSceneLoader.LoadSceneAsync(
                Constants.MatchBundleKeys.MatchSceneKey, 
                LoadSceneMode.Single, 
                true,
                true);
        }
    }
}