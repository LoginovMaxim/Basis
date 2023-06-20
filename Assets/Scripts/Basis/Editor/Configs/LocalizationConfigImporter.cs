using Editor.Configs;

namespace Basis.Editor.Configs
{
    public sealed class LocalizationConfigImporter : ConfigImporter
    {
        private static readonly IConfigEntityImporter[] _configEntityImporters = new IConfigEntityImporter[]
        {
            new LocalizationConfigEntityImporter()
        };

        protected override IConfigEntityImporter[] ConfigEntityImporters => _configEntityImporters;
    }
}