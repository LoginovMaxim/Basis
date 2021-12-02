using System.Threading.Tasks;

namespace ViewModels
{
    public interface ILocalizationDataProvider
    {
        LocalizationData LocalizationData { get; }
        
        Task Load();
    }
}