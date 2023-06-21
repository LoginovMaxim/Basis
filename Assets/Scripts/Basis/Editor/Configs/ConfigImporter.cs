using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Basis.App.Configs;

namespace Basis.Editor.Configs
{
    public abstract class ConfigImporter : IConfigImporter
    {
        protected abstract IConfigEntityImporter[] ConfigEntityImporters { get; }

        public async Task<byte[]> ImportAsync(ISheetSource sheetSource, CancellationToken token)
        {
            var entities = new List<IConfigEntity>();
            foreach (var configEntityImporters in ConfigEntityImporters)
            {
                entities.AddRange(await configEntityImporters.Import(sheetSource, token));
            }
            return BinaryConfig.Save(entities);
        }
    }
}