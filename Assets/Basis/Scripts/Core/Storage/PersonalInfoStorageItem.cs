using System;
using BasisCore.Storage;

namespace Basis.Core.Storage
{
    [Serializable] 
    public class PersonalInfoStorageItem : StorageItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}