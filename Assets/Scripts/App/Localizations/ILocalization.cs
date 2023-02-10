using System;
using System.Collections.Generic;

namespace App.Localizations
{
    public interface ILocalization
    {
        Action OnLanguageChanged { get; set; }
        Language Language { get; }
        List<string> Keys { get; }
        Dictionary<string, Dictionary<string, string>> Table { get; }
        void InitializeLocalizationTable(Dictionary<string, Dictionary<string, string>> table);
        string GetString(string key);
        void SetLanguage(Language language);
    }
}