using System.Threading;
using Basis.Core.Services;
using BasisCore.Launchers;
using Cysharp.Threading.Tasks;

namespace Basis.Core.Launchers
{
    public sealed class MetaSceneLauncher : ILauncher
    {
        private readonly IMetaSceneLoader _metaSceneLoader;

        public MetaSceneLauncher(IMetaSceneLoader metaSceneLoader)
        {
            _metaSceneLoader = metaSceneLoader;
        }

        public async UniTask LaunchAsync(CancellationToken token)
        {
            await _metaSceneLoader.LoadAsync(token);
        }
    }
}