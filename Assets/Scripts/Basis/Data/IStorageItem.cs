using System;

namespace Basis.Data
{
    public interface IStorageItem
    {
        public event Action OnItemChanged;
    }
}