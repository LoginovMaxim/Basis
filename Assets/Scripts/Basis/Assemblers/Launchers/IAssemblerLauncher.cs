using System.Threading;
using Cysharp.Threading.Tasks;

namespace Basis.Assemblers.Launchers
{
    public interface IAssemblerLauncher
    {
        UniTask Launch(CancellationToken token);
    }
}