using System;
using System.Collections.Generic;

namespace App.Localizations
{
    public interface ILocalizationSingleton
    {
        event Action OnLocaleChanged;

        string Locale { get; set; }

        string GetLocaleOrDefault(string locale);

        IEnumerable<string> Locales { get; }
    }
}