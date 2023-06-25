using System.Threading;
using Basis.App.Assemblers;
using Cysharp.Threading.Tasks;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleAuthorization : IAssemblerPart
    {
        public async UniTask Launch(CancellationToken token)
        {
            // authorization pipeline
            await UniTask.Delay(200);
        }
    }
}