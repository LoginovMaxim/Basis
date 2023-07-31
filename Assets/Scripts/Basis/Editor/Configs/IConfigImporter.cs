using System.Threading;
using System.Threading.Tasks;

namespace Basis.Editor.Configs
{
    public interface IConfigImporter
    {
        Task<byte[]> ImportAsync(ISheetSource sheetSource, CancellationToken token);
    }
}