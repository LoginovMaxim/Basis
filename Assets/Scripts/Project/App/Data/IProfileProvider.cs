namespace Project.App.Data
{
    public interface IProfileProvider
    {
        PersonalInfoStorageItem PersonalInfoData { get; }
        ProgressStorageItem ProgressData { get; }
        CurrencyStorageItem CurrencyData { get; }
    }
}