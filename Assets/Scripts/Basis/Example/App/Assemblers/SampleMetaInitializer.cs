using System.Threading;
using Basis.App.Assemblers;
using Cysharp.Threading.Tasks;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleMetaInitializer : IAssemblerPart
    {
        public UniTask Launch(CancellationToken token)
        {
            return UniTask.CompletedTask;
        }
    }
}