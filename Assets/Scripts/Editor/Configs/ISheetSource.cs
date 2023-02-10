using System.Threading;
using System.Threading.Tasks;

namespace Editor.Configs
{
    public interface ISheetSource
    {
        Task<ISheet> GetSheetAsync(string sheetName, CancellationToken token);
    }
}