using System.Threading;
using Basis.SceneLoaders;
using Basis.Services;
using Basis.UI.Splashes;
using Cysharp.Threading.Tasks;
using Project.App.Data;
using UnityEngine.SceneManagement;

namespace Project.App.Services
{
    public sealed class MetaSceneLoader : AsyncLoader, IMetaSceneLoader
    {
        private readonly IAddressableSceneLoader _addressableSceneLoader;
        private readonly ISplash _splash;

        public MetaSceneLoader(IAddressableSceneLoader addressableSceneLoader, ISplash splash)
        {
            _addressableSceneLoader = addressableSceneLoader;
            _splash = splash;
        }

        public override async UniTask LoadAsync(CancellationToken token)
        {
            await _splash.Show();
            
            await _addressableSceneLoader.LoadSceneAsync(
                Constants.MetaBundleKeys.MetaSceneKey, 
                LoadSceneMode.Single, 
                true,
                true);
        }
    }
}