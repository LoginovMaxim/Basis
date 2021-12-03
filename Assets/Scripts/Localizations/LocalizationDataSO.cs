using System;
using System.Collections.Generic;
using UnityEngine;

namespace Localizations
{
    [CreateAssetMenu(fileName = "LocalizationData", menuName = "LocalizationData", order = 0)]
    public class LocalizationDataSO : ScriptableObject
    {
        public List<LocalizationTable> LocalizationTables;
    }

    [Serializable]
    public class LocalizationTable
    {
        public string ID;
        public string EN;
        public string RU;
    }
}