using App.Configs;

namespace Editor.Configs
{
    public interface IConfigEntitySubImporter
    {
        IConfigEntity Import(ISheet sheet);
    }
}