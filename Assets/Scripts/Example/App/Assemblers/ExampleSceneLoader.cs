using System.Threading.Tasks;
using App.Assemblers;
using App.Monos;
using UnityEngine.SceneManagement;

namespace Example.App.Assemblers
{
    public sealed class ExampleSceneLoader : IAssemblerPart
    {
        private const string MetaScenePath = "Scenes/Example";
        
        private readonly ISceneLoader _sceneLoader;

        public ExampleSceneLoader(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async Task Launch()
        {
            await _sceneLoader.LoadSceneAsync(MetaScenePath, true, LoadSceneMode.Single);
        }
    }
}