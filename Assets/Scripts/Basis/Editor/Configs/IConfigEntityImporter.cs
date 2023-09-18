using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Basis.Configs;
using Basis.Configs.BinaryConfigs;

namespace Basis.Editor.Configs
{
    public interface IConfigEntityImporter
    {
        Task<List<IConfigEntity>> Import(ISheetSource sheetSource, CancellationToken token);
    }
}