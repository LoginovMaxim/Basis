using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Configs;

namespace Editor.Configs
{
    public abstract class ConfigImporter : IConfigImporter
    {
        protected abstract IConfigEntityImporter[] ConfigEntityImporters { get; }

        private async Task<byte[]> ImportAsync(ISheetSource sheetSource, CancellationToken token)
        {
            var entities = new List<IConfigEntity>();
            foreach (var configEntityImporters in ConfigEntityImporters)
            {
                entities.AddRange(await configEntityImporters.Import(sheetSource, token));
            }
            return BinaryConfig.Save(entities);
        }

        #region IConfigImporter

        Task<byte[]> IConfigImporter.Import(ISheetSource sheetSource, CancellationToken token)
        {
            return ImportAsync(sheetSource, token);
        }

        #endregion
    }
}