using System.Threading;
using Basis.App.Monos;
using Basis.App.UI.Splashes;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Basis.Example.App.Services
{
    public class SampleMetaSceneLoader : ISampleMetaSceneLoader
    {
        private const string SampleMetaScenePath = "Basis/Example/Scenes/MetaExample";
        
        private readonly ISceneLoader _sceneLoader;
        private readonly ISplash _splash;

        public SampleMetaSceneLoader(ISceneLoader sceneLoader, ISplash splash)
        {
            _sceneLoader = sceneLoader;
            _splash = splash;
        }

        public async UniTask LoadAsync(CancellationToken token)
        {
            _splash.Show();
            await _sceneLoader.LoadSceneAsync(SampleMetaScenePath, false, LoadSceneMode.Additive, token);
        }
    }
}