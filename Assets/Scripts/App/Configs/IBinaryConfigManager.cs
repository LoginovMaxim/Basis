﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Configs
{
    public interface IBinaryConfigManager
    {
        BinaryConfigId[] ConfigIds { get; }
        IBinaryConfig GetConfig(BinaryConfigId binaryConfigId);
        Task<bool> LoadLocal(bool cached, CancellationToken token);
        IHandle SubscribeToUpdate(BinaryConfigId binaryConfigId, Action onConfigUpdate);
    }
}