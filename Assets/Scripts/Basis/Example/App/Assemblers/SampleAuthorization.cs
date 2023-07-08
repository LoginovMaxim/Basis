using System.Threading;
using Basis.App.Assemblers;
using Cysharp.Threading.Tasks;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleAuthorization : IAssemblerPart
    {
        public UniTask Launch(CancellationToken token)
        {
            return UniTask.CompletedTask;
        }
    }
}