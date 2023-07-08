using System.Threading;
using Basis.App.Assemblers;
using Basis.Example.App.Services;
using Cysharp.Threading.Tasks;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleMetaLauncher : IAssemblerPart
    {
        private readonly ISampleMetaSceneLoader _sampleMetaSceneLoader;

        public SampleMetaLauncher(ISampleMetaSceneLoader sampleMetaSceneLoader)
        {
            _sampleMetaSceneLoader = sampleMetaSceneLoader;
        }

        public async UniTask Launch(CancellationToken token)
        {
            await _sampleMetaSceneLoader.LoadAsync(token);
        }
    }
}