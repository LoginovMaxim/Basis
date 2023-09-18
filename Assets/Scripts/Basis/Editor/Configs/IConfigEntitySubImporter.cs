using Basis.Configs;
using Basis.Configs.BinaryConfigs;

namespace Basis.Editor.Configs
{
    public interface IConfigEntitySubImporter
    {
        IConfigEntity Import(ISheet sheet);
    }
}