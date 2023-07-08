using System.Threading;
using Cysharp.Threading.Tasks;

namespace Basis.Assemblers
{
    public interface IAssemblerPart
    {
        UniTask Launch(CancellationToken token);
    }
}