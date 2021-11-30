using System;
using System.Collections.Generic;

namespace ViewModels
{
    [Serializable]
    public class LocalizationData
    {
        public Dictionary<string, Dictionary<Language, string>> Data;
    }
}