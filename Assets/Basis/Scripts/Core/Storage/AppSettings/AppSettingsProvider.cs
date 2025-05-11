using BasisCore.Storage;

namespace Basis.Core.Storage
{
    public sealed class AppSettingsProvider : StorageItemProviderBase<AppSettingsStorageItem>
    {
        public bool IsMuteMusic => _storageItem.IsMuteMusic;
        public bool IsMuteSounds => _storageItem.IsMuteSounds;
        public bool IsVibration => _storageItem.IsVibration;

        public void SetMuteMusic(bool mute)
        {
            _storageItem.IsMuteMusic = mute;
            Save();
        }

        public void SetMuteSounds(bool mute)
        {
            _storageItem.IsMuteSounds = mute;
            Save();
        }

        public void SetVibration(bool vibration)
        {
            _storageItem.IsVibration = vibration;
            Save();
        }
    }
}