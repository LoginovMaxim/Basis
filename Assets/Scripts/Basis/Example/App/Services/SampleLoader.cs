using System.Threading;
using Basis.App.Assemblers;
using Cysharp.Threading.Tasks;

namespace Basis.Example.App.Services
{
    public sealed class SampleLoader : ISampleLoader, IAssemblerPart
    {
        public async UniTask Launch(CancellationToken token)
        {
            await UniTask.Delay(100);
        }
    }
}