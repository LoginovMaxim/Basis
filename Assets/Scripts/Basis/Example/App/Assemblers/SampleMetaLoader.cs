using System.Threading.Tasks;
using Basis.App.Assemblers;
using Basis.App.Monos;
using UnityEngine.SceneManagement;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleMetaLoader : IAssemblerPart
    {
        private const string SampleMetaScenePath = "Example/Scenes/MetaExample";
        
        private readonly ISceneLoader _sceneLoader;

        public SampleMetaLoader(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async Task Launch()
        {
            await _sceneLoader.LoadSceneAsync(SampleMetaScenePath, true, LoadSceneMode.Single);
        }
    }
}