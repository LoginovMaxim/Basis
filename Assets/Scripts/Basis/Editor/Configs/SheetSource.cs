using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Sheets.v4;

namespace Basis.Editor.Configs
{
    public sealed class SheetSource : ISheetSource
    {
        private readonly string _spreadsheetId;
        private readonly SheetsService _sheetsService;
        private readonly Dictionary<string, ISheet> _sheets = new Dictionary<string, ISheet>();

        public SheetSource(string spreadsheetId, SheetsService sheetsService)
        {
            _spreadsheetId = spreadsheetId;
            _sheetsService = sheetsService;
        }

        public async Task<ISheet> GetSheetAsync(string sheetName, CancellationToken token)
        {
            if (_sheets.TryGetValue(sheetName, out var sheet))
            {
                return sheet;
            }
            var values = await GoogleConfigDownloader.GetSheetAsync(_sheetsService, _spreadsheetId, sheetName, token);
            sheet = new Sheet(sheetName, values);
            _sheets.Add(sheetName, sheet);
            return sheet;
        }

    }
}