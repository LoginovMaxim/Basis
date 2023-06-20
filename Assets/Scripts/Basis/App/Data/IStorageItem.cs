using System;

namespace Basis.App.Data
{
    public interface IStorageItem
    {
        Action OnItemChanged { get; set; }
    }
}