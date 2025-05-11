using System;
using BasisCore.Storage;

namespace Basis.Core.Storage
{
    [Serializable]
    public class ProgressStorageItem : IStorageItem
    {
        public int Level { get; set; } = 1;
        public int Experience { get; set; }
    }
}