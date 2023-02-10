using System.Threading;
using System.Threading.Tasks;

namespace Editor.Configs
{
    public interface IConfigImporter
    {
        Task<byte[]> Import(ISheetSource sheetSource, CancellationToken token);
    }
}