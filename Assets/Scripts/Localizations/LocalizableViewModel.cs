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
                
                if (!localizationData.Data[property.Name].TryGetValue(language, out var translateProperty))
                    continue;

                property.SetValue(this, translateProperty);
            }
        }
    }
}