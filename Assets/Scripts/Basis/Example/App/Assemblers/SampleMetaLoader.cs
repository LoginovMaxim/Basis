using System.Threading;
using Basis.App.Assemblers;
using Basis.App.Monos;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleMetaLoader : IAssemblerPart
    {
        private const string SampleMetaScenePath = "Basis/Example/Scenes/MetaExample";
        
        private readonly ISceneLoader _sceneLoader;

        public SampleMetaLoader(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async UniTask Launch(CancellationToken token)
        {
            await _sceneLoader.LoadSceneAsync(SampleMetaScenePath, true, LoadSceneMode.Single);
        }
    }
}