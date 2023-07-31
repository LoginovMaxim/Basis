using System;
using System.Collections.Generic;

namespace Basis.Localizations
{
    public interface ILocalization
    {
        public event Action OnLanguageChanged;
        public Language Language { get; }
        public List<string> Keys { get; }
        public Dictionary<int, Dictionary<string, string>> Table { get; }
        public void InitializeLocalizationTable(Dictionary<int, Dictionary<string, string>> table);
        public string GetString(string key, params object[] args);
        public void SetLanguage(Language language);
    }
}