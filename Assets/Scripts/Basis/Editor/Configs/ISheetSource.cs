using System.Threading;
using System.Threading.Tasks;

namespace Basis.Editor.Configs
{
    public interface ISheetSource
    {
        Task<ISheet> GetSheetAsync(string sheetName, CancellationToken token);
    }
}