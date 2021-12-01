using System;
using System.Collections.Generic;

namespace ViewModels
{
    [Serializable]
    public class LocalizationData
    {
        public Dictionary<string, Dictionary<string, object>> Data;
    }
}