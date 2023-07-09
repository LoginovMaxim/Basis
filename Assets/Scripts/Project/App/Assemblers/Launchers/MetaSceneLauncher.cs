using System.Threading;
using Basis.Assemblers.Launchers;
using Cysharp.Threading.Tasks;
using Project.App.Services;

namespace Project.App.Assemblers.Launchers
{
    public sealed class MetaSceneLauncher : IAssemblerLauncher
    {
        private readonly IMetaSceneLoader _metaSceneLoader;

        public MetaSceneLauncher(IMetaSceneLoader metaSceneLoader)
        {
            _metaSceneLoader = metaSceneLoader;
        }

        public async UniTask Launch(CancellationToken token)
        {
            await _metaSceneLoader.LoadAsync(token);
        }
    }
}