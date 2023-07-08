using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Basis.Localizations
{
    public sealed class Localization : ILocalization
    {
        public Action OnLanguageChanged { get; set; }
        
        public Language Language => _language;
        public Dictionary<int, Dictionary<string, string>> Table => _table;
        public List<string> Keys => _table[(int) Language.English].Keys.ToList();
        
        private Language _language = Language.English;
        private Dictionary<int, Dictionary<string, string>> _table;
        
        public void InitializeLocalizationTable(Dictionary<int, Dictionary<string, string>> table)
        {
            _table = table;
        }
        
        public string GetString(string key, params object[] args)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new Exception($"Empty key");
            }
            
            if (!_table.TryGetValue((int) _language, out var locale))
            {
                throw new Exception($"Missing language {_language} localization");
            }

            if (!locale.TryGetValue(key, out var localizationText))
            {
                throw new Exception($"Missing key {key} localization");
            }
            
            try
            {
                return args.Length > 0 ? string.Format(localizationText, args) : localizationText;
            }
            catch
            {
                Debug.LogError($"Key '{key}' doesn't exist");
                return $"<{key}>";
            }
        }

        public void SetLanguage(Language language)
        {
            if (_language == language)
            {
                return;
            }
            _language = language;
            OnLanguageChanged?.Invoke();
        }
    }
}