using System;

namespace App.Data
{
    public interface IStorageItem
    {
        Action OnItemChanged { get; set; }
    }
}