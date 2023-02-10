using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Configs;

namespace Editor.Configs
{
    public interface IConfigEntityImporter
    {
        Task<List<IConfigEntity>> Import(ISheetSource sheetSource, CancellationToken token);
    }
}