using System;
using System.Collections.Generic;

namespace Basis.Configs
{
    [Serializable] public sealed class LocalizationConfigEntity : ConfigEntity
    {
        public const string InstanceId = "LOCALIZATION_CONFIG";

        public int[] Languages;
        public LocalizationRecord[] Records;

        public Dictionary<int, Dictionary<string, string>> ToTables()
        {
            var tables = new Dictionary<int, Dictionary<string, string>>();
            for (var i = 0; i < Languages.Length; ++i)
            {
                var language = Languages[i];
                var table = new Dictionary<string, string>();
                for (var j = 0; j < Records.Length; ++j)
                {
                    var record = Records[j];
                    table.Add(record.Key, record.Strings[i]);
                }
                tables.Add(language, table);
            }
            return tables;
        }
    }
}