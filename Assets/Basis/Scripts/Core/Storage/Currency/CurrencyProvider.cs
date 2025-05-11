using BasisCore.Storage;
namespace Basis.Core.Storage
{
    public sealed class CurrencyProvider : StorageItemProviderBase<CurrencyStorageItem>
    {
        public int Soft => _storageItem.Soft;
        public int Hard => _storageItem.Hard;

        public void AddSoft(int value)
        {
            _storageItem.Soft += value;
            Save();
        }

        public bool TrySubtractSoft(int value)
        {
            if (_storageItem.Soft < value)
            {
                return false;
            }
            
            _storageItem.Soft -= value;
            Save();
            
            return true;
        }

        public void AddHard(int value)
        {
            _storageItem.Hard += value;
            Save();
        }

        public bool TrySubtractHard(int value)
        {
            if (_storageItem.Hard < value)
            {
                return false;
            }
            
            _storageItem.Hard -= value;
            Save();
            
            return true;
        }
    }
}