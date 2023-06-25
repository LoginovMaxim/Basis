using System.Threading;
using Basis.App.Assemblers;
using Cysharp.Threading.Tasks;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleMetaInitializer : IAssemblerPart
    {
        public async UniTask Launch(CancellationToken token)
        {
            await UniTask.Delay(500);
        }
    }
}