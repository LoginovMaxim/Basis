using System;

namespace App.Localizations
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