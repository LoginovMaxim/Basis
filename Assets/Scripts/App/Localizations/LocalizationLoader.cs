using System.Threading;
using System.Threading.Tasks;
using App.Assemblers;
using App.Configs;

namespace App.Localizations
{
    public sealed class LocalizationLoader : IAssemblerPart
    {
        private readonly IBinaryConfigManager _binaryConfigManager;
        private readonly ILocalization _localization;

        private Language _language = Language.EN;
        
        public LocalizationLoader(IBinaryConfigManager binaryConfigManager, ILocalization localization)
        {
            _binaryConfigManager = binaryConfigManager;
            _localization = localization;
        }

        public async Task Launch()
        {
            await _binaryConfigManager.LoadLocal(true, new CancellationToken());
            
            var localizationConfig = _binaryConfigManager.GetConfig(BinaryConfigId.Localization);
            var entity = localizationConfig.GetEntity<LocalizationConfigEntity>(LocalizationConfigEntity.InstanceId);

            _localization.InitializeLocalizationTable(entity.ToTables());
        }
    }
}