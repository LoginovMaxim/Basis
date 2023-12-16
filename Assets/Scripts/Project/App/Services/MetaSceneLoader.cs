using System;
using System.Threading;
using BasisCore.Runtime.SceneLoaders;
using BasisCore.Runtime.UI.Splashes;
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
        private readonly ISplash _splash;

        public MetaSceneLoader(ISceneLoader sceneLoader, ISplash splash)
        {
            _sceneLoader = sceneLoader;
            _splash = splash;
        }

        public async UniTask LoadAsync(CancellationToken token)
        {
            _splash.Show();
            
            await _sceneLoader.LoadSceneAsync(
                Constants.MetaBundleKeys.MetaSceneKey, 
                LoadSceneMode.Single, 
                true,
                token);
        }

        public async UniTask UnloadAsync(CancellationToken token)
        {
            _splash.Show();
            
            await _sceneLoader.UnloadSceneAsync(Constants.MetaBundleKeys.MetaSceneKey, token);
        }
    }
}