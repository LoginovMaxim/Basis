using Basis.Configs;

namespace Basis.Editor.Configs
{
    public interface IConfigEntitySubImporter
    {
        IConfigEntity Import(ISheet sheet);
    }
}