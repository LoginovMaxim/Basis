using System.Threading;
using Basis.Assemblers;
using Basis.Configs;
using Cysharp.Threading.Tasks;

namespace Basis.Localizations
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