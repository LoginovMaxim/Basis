namespace Basis.Core.Storage
{
    public interface IProfileProvider
    {
        PersonalInfoStorageItem PersonalInfoData { get; }
        ProgressStorageItem ProgressData { get; }
        CurrencyStorageItem CurrencyData { get; }
    }
}