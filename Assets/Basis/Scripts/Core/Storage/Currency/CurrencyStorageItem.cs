﻿using System;
using BasisCore.Storage;

namespace Basis.Core.Storage
{
    [Serializable] 
    public class CurrencyStorageItem : IStorageItem
    {
        public int Soft { get; set; }
        public int Hard { get; set; }
    }
}