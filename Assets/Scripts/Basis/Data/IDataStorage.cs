namespace Basis.Data
{
    public interface IDataStorage<T> where T : IStorageItem
    {
        T Item { get; }
    }
}