using System;

namespace Basis.App.Localizations
{
    [System.AttributeUsage(AttributeTargets.Property)]
    public class LocalizationAttribute : Attribute
    {
        public string Key;

        public LocalizationAttribute(string key)
        {
            Key = key;
        }
    }
}