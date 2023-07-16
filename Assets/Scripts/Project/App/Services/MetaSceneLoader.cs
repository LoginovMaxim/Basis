using System.Threading;
using Basis.SceneLoaders;
using Basis.Services;
using Basis.UI.Splashes;
using Cysharp.Threading.Tasks;
using Project.App.Data;
using Project.Meta.UI;
using UnityEngine.SceneManagement;

namespace Project.App.Services
{
    public sealed class MetaSceneLoader : AsyncLoader, IMetaSceneLoader
    {
        private readonly IMetaScreenService _metaScreenService;
        private readonly ISceneLoader _sceneLoader;
        private readonly ISplash _splash;

        public MetaSceneLoader(ISceneLoader sceneLoader, ISplash splash)
        {
            _sceneLoader = sceneLoader;
            _splash = splash;
        }

        public override async UniTask LoadAsync(CancellationToken token)
        {
            _splash.Show();
            
            await _sceneLoader.LoadSceneAsync(
                Constants.MetaBundleKeys.MetaSceneKey, 
                LoadSceneMode.Single, 
                true,
                token);
        }
    }
}