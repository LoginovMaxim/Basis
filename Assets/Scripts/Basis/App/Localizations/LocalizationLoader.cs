using System.Threading;
using System.Threading.Tasks;
using Basis.App.Assemblers;
using Basis.App.Configs;
using Cysharp.Threading.Tasks;

namespace Basis.App.Localizations
{
    public sealed class LocalizationLoader : IAssemblerPart
    {
        private readonly IBinaryConfigManager _binaryConfigManager;
        private readonly ILocalization _localization;

        private Language _language = Language.English;
        
        public LocalizationLoader(IBinaryConfigManager binaryConfigManager, ILocalization localization)
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