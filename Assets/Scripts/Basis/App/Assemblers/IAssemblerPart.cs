using System.Threading;
using Cysharp.Threading.Tasks;

namespace Basis.App.Assemblers
{
    public interface IAssemblerPart
    {
        UniTask Launch(CancellationToken token);
    }
}