using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Configs;

namespace Editor.Configs
{
    public sealed class LocalizationConfigEntityImporter : IConfigEntityImporter
    {
        private async Task<List<IConfigEntity>> ImportAsync(ISheetSource sheetSource, CancellationToken token)
        {
            var sheet = await sheetSource.GetSheetAsync(SheetNames.Localization, token);
            var rows = sheet.GetRows();
            var languages = new List<string>();
            
            var header = sheet.Header;
            for (var i = 1; i < header.Length; ++i)
            {
                languages.Add(header[i]);
            }
            
            var records = new List<LocalizationRecord>();
            for (var i = 0; i < rows.Count; ++i)
            {
                var row = rows[i];
                var key = (string)row.GetValueByIndex(0);
                var strings = new List<string>();
                
                for (var j = 1; j < row.Length; ++j)
                {
                    strings.Add((string)row.GetValueByIndex(j));
                }
                
                var record = new LocalizationRecord
                {
                    Key = key,
                    Strings = strings.ToArray()
                };
                
                records.Add(record);
            }
            
            var entity = new LocalizationConfigEntity
            {
                Id = LocalizationConfigEntity.InstanceId,
                Languages = languages.ToArray(),
                Records = records.ToArray()
            };
            
            return new List<IConfigEntity> { entity };
        }

        #region IConfigEntityImporter

        Task<List<IConfigEntity>> IConfigEntityImporter.Import(ISheetSource sheetSource, CancellationToken token)
        {
            return ImportAsync(sheetSource, token);
        }

        #endregion
    }
}