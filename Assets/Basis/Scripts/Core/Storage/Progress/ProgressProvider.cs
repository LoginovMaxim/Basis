using BasisCore.Storage;

namespace Basis.Core.Storage
{
    public sealed class ProgressProvider : StorageItemProviderBase<ProgressStorageItem>
    {
        public int Level => _storageItem.Level;
        public int Experience => _storageItem.Experience;
    }
}