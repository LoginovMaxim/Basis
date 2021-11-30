namespace ViewModels
{
    public interface ILocalizable
    {
        void TranslateViewModel(LocalizationData localizationData, Language language);
    }
}