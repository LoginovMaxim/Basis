using System;
using System.Collections.Generic;

namespace Basis.Localizations
{
    public interface ILocalization
    {
        Action OnLanguageChanged { get; set; }
        Language Language { get; }
        List<string> Keys { get; }
        Dictionary<int, Dictionary<string, string>> Table { get; }
        void InitializeLocalizationTable(Dictionary<int, Dictionary<string, string>> table);
        string GetString(string key, params object[] args);
        void SetLanguage(Language language);
    }
}