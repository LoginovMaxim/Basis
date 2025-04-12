using System;
using BasisCore.Storage;

namespace Basis.Core.Storage
{
    [Serializable] 
    public sealed class AppSettingsStorageItem : StorageItem
    {
        public bool IsMuteMusic { get; set; }
        public bool IsMuteSounds { get; set; }
        public bool IsVibration { get; set; }
    }
}