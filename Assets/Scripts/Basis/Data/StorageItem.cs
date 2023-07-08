using System;

namespace Basis.Data
{
    public abstract class StorageItem : IStorageItem
    {
        public event Action OnItemChanged;

        protected void SaveUpdatedItem()
        {
            OnItemChanged?.Invoke();
        }
    }
}