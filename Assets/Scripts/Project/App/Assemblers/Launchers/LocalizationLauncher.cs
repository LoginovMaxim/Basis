using System.Threading;
using BasisCore.Runtime.Assemblers.Launchers;
using BasisCore.Runtime.Configs.Localization;
using BasisCore.Runtime.Localizations;
using Cysharp.Threading.Tasks;
using Project.App.Configs;

namespace Project.App.Assemblers.Launchers
{
    public sealed class LocalizationLauncher : IAssemblerLauncher
    {
        private readonly IProjectBinaryConfigManager _binaryConfigManager;
        private readonly ILocalization _localization;

        private Language _language = Language.English;
        
        public LocalizationLauncher(IProjectBinaryConfigManager binaryConfigManager, ILocalization localization)
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
            await UniTask.Delay(500, cancellationToken: token);
        }
    }
}