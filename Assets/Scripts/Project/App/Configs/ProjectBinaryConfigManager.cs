using BasisCore.Runtime.Configs.BinaryConfigs;
using BasisCore.Runtime.ResourceProviders;

namespace Project.App.Configs
{
    public sealed class ProjectBinaryConfigManager : BaseBinaryConfigManager<BinaryConfigId>, IProjectBinaryConfigManager
    {
        public ProjectBinaryConfigManager(IResourceProvider resourceProvider) : base(resourceProvider)
        {
        }
    }
}