using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Basis.Configs
{
    public interface IBinaryConfigManager
    {
        BinaryConfigId[] ConfigIds { get; }
        IBinaryConfig GetConfig(BinaryConfigId binaryConfigId);
        UniTask<bool> LoadLocalAsync(bool cached, CancellationToken token);
        IHandle SubscribeToUpdate(BinaryConfigId binaryConfigId, Action onConfigUpdate);
    }
}