using System.Threading;
using Basis.Assemblers.Launchers;
using Basis.Configs;
using Basis.Localizations;
using Cysharp.Threading.Tasks;

namespace Project.App.Assemblers.Launchers
{
    public sealed class LocalizationLauncher : IAssemblerLauncher
    {
        private readonly IBinaryConfigManager _binaryConfigManager;
        private readonly ILocalization _localization;

        private Language _language = Language.English;
        
        public LocalizationLauncher(IBinaryConfigManager binaryConfigManager, ILocalization localization)
        {
            _binaryConfigManager = binaryConfigManager;
            _localization = localization;
        }

        public async UniTask Launch(CancellationToken token)
        {
            await _binaryConfigManager.LoadLocalAsync(true, new CancellationToken());
            
            var localizationConfig = _binaryConfigManager.GetConfig(BinaryConfigId.Localization);
            var entity = localizationConfig.GetEntity<LocalizationConfigEntity>(LocalizationConfigEntity.InstanceId);

            _localization.InitializeLocalizationTable(entity.ToTables());
        }
    }
}