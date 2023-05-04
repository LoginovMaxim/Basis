namespace App.Data
{
    public interface IDataStorage<T> where T : IStorageItem
    {
        T Data { get; }
    }
}