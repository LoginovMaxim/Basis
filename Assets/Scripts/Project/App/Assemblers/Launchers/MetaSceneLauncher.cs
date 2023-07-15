using System.Threading;
using System.Threading.Tasks;
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
            await UniTask.Delay(500, cancellationToken: token);
            await _metaSceneLoader.LoadAsync(token);
            await UniTask.Delay(500, cancellationToken: token);
        }
    }
}