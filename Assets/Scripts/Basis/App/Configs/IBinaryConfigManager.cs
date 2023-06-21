using System;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.App.Configs
{
    public interface IBinaryConfigManager
    {
        BinaryConfigId[] ConfigIds { get; }
        IBinaryConfig GetConfig(BinaryConfigId binaryConfigId);
        Task<bool> LoadLocalAsync(bool cached, CancellationToken token);
        IHandle SubscribeToUpdate(BinaryConfigId binaryConfigId, Action onConfigUpdate);
    }
}