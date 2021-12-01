using System;

namespace ViewModels
{
    public abstract class LocalizableViewModel : ViewModel, ILocalizable
    {
        public virtual void TranslateViewModel(LocalizationData localizationData, Language language)
        {
            foreach (var property in GetType().GetProperties())
            {
                if (property.PropertyType != typeof(string))
                    continue;
                
                if (!localizationData.Data.ContainsKey(property.Name))
                    continue;

                var languageName = Enum.GetName(typeof(Language), language);
                if (!localizationData.Data[property.Name].TryGetValue(languageName, out var translateProperty))
                    continue;

                property.SetValue(this, translateProperty);
            }
        }
    }
}