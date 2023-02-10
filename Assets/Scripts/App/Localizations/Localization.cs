using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Localizations
{
    public sealed class Localization : ILocalization
    {
        public static Localization Instance { get; private set; }
        
        private Language _language = Language.EN;
        private Dictionary<string, Dictionary<string, string>> _table;

        public Localization()
        {
            Instance = this;
        }

        private string GetString(string key)
        {
            return _table[_language.ToString()][key];
        }

        #region ILocalization

        public Action OnLanguageChanged { get; set; }
        Language ILocalization.Language => _language;
        Dictionary<string, Dictionary<string, string>> ILocalization.Table => _table;
        List<string> ILocalization.Keys => _table[Language.EN.ToString()].Keys.ToList();
        
        void ILocalization.InitializeLocalizationTable(Dictionary<string, Dictionary<string, string>> table)
        {
            _table = table;
        }

        string ILocalization.GetString(string key)
        {
            return GetString(key);
        }

        void ILocalization.SetLanguage(Language language)
        {
            _language = language;
            OnLanguageChanged?.Invoke();
        }

        #endregion
    }
}