using System;

namespace Basis.App.Data
{
    public abstract class StorageItem : IStorageItem
    {
        public Action OnItemChanged { get; set; }

        protected void SaveUpdatedItem()
        {
            OnItemChanged?.Invoke();
        }
    }
}