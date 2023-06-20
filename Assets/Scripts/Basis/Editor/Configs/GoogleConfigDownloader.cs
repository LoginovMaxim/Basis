using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;

namespace Basis.Editor.Configs
{
    public class GoogleConfigDownloader
    {
        #region Constants

        private const string ApplicationName = "Google Sheets API .NET Quickstart";
        private const string CredentialsFileName = "credentials.json";
        private const string AccessTokenPath = "Token";

        #endregion

        private static readonly string[] _scopes = { SheetsService.Scope.SpreadsheetsReadonly };

        public static async Task<SheetsService> CreateSheetsServiceAsync(string userName, CancellationToken token)
        {
            using var stream = new FileStream(CredentialsFileName, FileMode.Open, FileAccess.Read);
            var secrets = GoogleClientSecrets.Load(stream).Secrets;
            var dataStore = new FileDataStore(AccessTokenPath, true);
            var credentials = await GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, _scopes, userName, token, dataStore);
            var initializer = new BaseClientService.Initializer() { ApplicationName = ApplicationName, HttpClientInitializer = credentials };
            return new SheetsService(initializer);
        }

        public static async Task<IList<IList<object>>> GetSheetAsync(SheetsService service, string spreadsheetId, string sheetName, CancellationToken token)
        {
            var request = service.Spreadsheets.Values.Get(spreadsheetId, sheetName);
            request.MajorDimension = SpreadsheetsResource.ValuesResource.GetRequest.MajorDimensionEnum.ROWS;
            request.ValueRenderOption = SpreadsheetsResource.ValuesResource.GetRequest.ValueRenderOptionEnum.UNFORMATTEDVALUE;
            var response = await request.ExecuteAsync(token);
            return response.Values;
        }
    }
}