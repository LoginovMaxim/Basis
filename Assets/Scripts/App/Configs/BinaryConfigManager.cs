using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace App.Configs
{
    public sealed class BinaryConfigManager : IBinaryConfigManager, IDisposable
    {
        #region Constants

        private const string TimestampName = "ConfigTimestamp";
        private const string TimestampVersionName = "ConfigTimestampVersion";
        private const string Version = "0.0.0";

        #endregion

        private static readonly BinaryConfigId[] _configIds = GetBinaryConfigIds();

        private readonly string _cachedBinaryConfigVersion;
        private readonly IBinaryConfig[] _binaryConfigs;
        private readonly Dictionary<BinaryConfigId, IBinaryConfig> _binaryConfigById = new Dictionary<BinaryConfigId, IBinaryConfig>();
        private readonly Dictionary<BinaryConfigId, HashSet<UpdateSubscriprion>> _updateSubscriptionHashSetByBinaryConfigId = new Dictionary<BinaryConfigId, HashSet<UpdateSubscriprion>>();
        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private readonly List<UpdateSubscriprion> _subscriptions = new List<UpdateSubscriprion>();

        private readonly IResourceProvider _resourceProvider;

        private bool _disposed;

        public BinaryConfigManager(IResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;

            _binaryConfigs = new IBinaryConfig[_configIds.Length];
            for (var i = 0; i < _configIds.Length; ++i)
            {
                var binaryConfigId = _configIds[i];
                var binaryConfig = new BinaryConfig();
                _binaryConfigs[i] = binaryConfig;
                _binaryConfigById.Add(binaryConfigId, binaryConfig);
                _updateSubscriptionHashSetByBinaryConfigId.Add(binaryConfigId, new HashSet<UpdateSubscriprion>());
            }
        }

        private IBinaryConfig GetConfig(BinaryConfigId binaryConfigId)
        {
            return _binaryConfigById[binaryConfigId];
        }

        private string GetCachedBinaryConfigVersion(BinaryConfigId binaryConfigId)
        {
            return PlayerPrefs.GetString(binaryConfigId.ToString(), _cachedBinaryConfigVersion);
        }

        private async Task<Tuple<bool, bool>> LoadStoredAsync(BinaryConfigId binaryConfigId, CancellationToken token)
        {
            Debug.Log($"/{ binaryConfigId }/ Load stored config");
            var tuple = await LoadStoredConfigAsync(binaryConfigId, token);
            if (tuple == null)
            {
                Debug.Log($"/{ binaryConfigId }/ Can not load stored config [NOT_FOUND]");
                return new Tuple<bool, bool>(false, false);
            }
            var config = GetConfig(binaryConfigId);
            if (!config.Empty && config.Timestamp == tuple.Item2)
            {
                Debug.Log($"/{ binaryConfigId }/ Config is actual");
                return new Tuple<bool, bool>(true, false);
            }
            if (!config.Load(tuple.Item1, tuple.Item2))
            {
                Debug.Log($"/{ binaryConfigId }/ Can not load stored config [CORRUPTED]");
                return new Tuple<bool, bool>(false, false);
            }
            Debug.Log($"/{ binaryConfigId }/ Stored config loaded");
            return new Tuple<bool, bool>(true, true);
        }

        private async Task<Tuple<bool, bool>> LoadCachedAsync(BinaryConfigId binaryConfigId, CancellationToken token)
        {
            Debug.Log($"/{ binaryConfigId }/ Load cached config");
            var tuple = await LoadCachedConfigAsync(binaryConfigId, token);
            if (tuple == null)
            {
                Debug.Log($"/{ binaryConfigId }/ Can not load cached config [NOT_FOUND]");
                return new Tuple<bool, bool>(false, false);
            }
            var config = GetConfig(binaryConfigId);
            if (!config.Empty && config.Timestamp == tuple.Item2)
            {
                Debug.Log($"/{ binaryConfigId }/ Config is actual");
                return new Tuple<bool, bool>(true, false);
            }
            if (!config.Load(tuple.Item1, tuple.Item2))
            {
                Debug.Log($"/{ binaryConfigId }/ Can not load cached config [CORRUPTED]");
                return new Tuple<bool, bool>(false, false);
            }
            Debug.Log($"/{ binaryConfigId }/ Cached config loaded");
            return new Tuple<bool, bool>(true, true);
        }

        private async Task<Tuple<byte[], long>> LoadStoredConfigAsync(BinaryConfigId binaryConfigId, CancellationToken token)
        {
            var resource = await _resourceProvider.LoadResource($"BinaryConfigs/{ GetBinaryConfigName(binaryConfigId) }", token);
            try
            {
                var textAsset = (TextAsset) resource;
                return new Tuple<byte[], long>(textAsset.bytes, 0);
            }
            catch (OperationCanceledException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                Debug.Log($"{ exception }");
            }
            return null;
        }

        private async Task<Tuple<byte[], long>> LoadCachedConfigAsync(BinaryConfigId binaryConfigId, CancellationToken token)
        {
            var fileName = GetCachedConfigFileName(binaryConfigId);
            try
            {
                using var fileStream = new FileStream(fileName, FileMode.Open);
                var timestampBytes = new byte[sizeof(long)];
                await fileStream.ReadAsync(timestampBytes, 0, timestampBytes.Length, token);
                var timestamp = BitConverter.ToInt64(timestampBytes, 0);
                var bytes = new byte[fileStream.Length - timestampBytes.Length];
                await fileStream.ReadAsync(bytes, 0, bytes.Length, token);
                return new Tuple<byte[], long>(bytes, timestamp);
            }
            catch (OperationCanceledException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                Debug.Log($"{ exception }");
            }
            return null;
        }

        private async Task<bool> CacheConfigAsync(BinaryConfigId binaryConfigId, byte[] bytes, long timestamp, CancellationToken token)
        {
            var fileName = GetCachedConfigFileName(binaryConfigId);
            try
            {
                using var fileStream = new FileStream(fileName, FileMode.Create);
                var timestampBytes = BitConverter.GetBytes(timestamp);
                await fileStream.WriteAsync(timestampBytes, 0, timestampBytes.Length, token);
                await fileStream.WriteAsync(bytes, 0, bytes.Length, token);

                PlayerPrefs.SetString(binaryConfigId.ToString(), Application.version);
                PlayerPrefs.Save();

                return true;
            }
            catch (OperationCanceledException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                Debug.Log($"{ exception }");
            }
            return false;
        }

        private async Task<bool> LoadLocalAsync(bool cached, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            Debug.Log($"Load local configs (cached = { cached })");
            try
            {
                for (var i = 0; i < _configIds.Length; ++i)
                {
                    var binaryConfigId = _configIds[i];
                    var cachedBinaryConfigVersion = GetCachedBinaryConfigVersion(binaryConfigId);
                    Debug.Log($"/{ binaryConfigId }/ Load config (cached app version = {cachedBinaryConfigVersion})");
                    Tuple<bool, bool> tuple;
                    if (cached && cachedBinaryConfigVersion == Application.version)
                    {
                        tuple = await LoadCachedAsync(binaryConfigId, _tokenSource.Token);
                        token.ThrowIfCancellationRequested();
                        var loaded = tuple.Item1;
                        if (loaded)
                        {
                            if (tuple.Item2)
                            {
                                NotifySubscribers(binaryConfigId);
                            }
                            continue;
                        }
                        Debug.Log($"/{ binaryConfigId }/ Problem cached config detected");
                        PlayerPrefs.DeleteKey(binaryConfigId.ToString());
                        PlayerPrefs.SetFloat(TimestampName, 0f);
                        PlayerPrefs.Save();
                    }
                    tuple = await LoadStoredAsync(binaryConfigId, _tokenSource.Token);
                    token.ThrowIfCancellationRequested();
                    var loadFailed = !tuple.Item1;
                    if (loadFailed)
                    {
                        return false;
                    }
                    if (tuple.Item2)
                    {
                        NotifySubscribers(binaryConfigId);
                    }
                }

                return true;
            }
            catch (OperationCanceledException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                Debug.Log($"{ exception }");
            }
            return false;
        }

        private IHandle SubscribeToUpdate(BinaryConfigId binaryConfigId, Action onConfigUpdate)
        {
            var subscription = new UpdateSubscriprion("binary_config_manager", onConfigUpdate);
            _updateSubscriptionHashSetByBinaryConfigId[binaryConfigId].Add(subscription);
            return subscription;
        }

        private void NotifySubscribers(BinaryConfigId binaryConfigId)
        {
            var subscriptions = _updateSubscriptionHashSetByBinaryConfigId[binaryConfigId];
            _subscriptions.Clear();
            _subscriptions.AddRange(subscriptions);
            var notifiedSubscrberCount = 0;
            for (var i = 0; i < _subscriptions.Count; ++i)
            {
                var subscription = _subscriptions[i];
                if (subscription.Disposed)
                {
                    subscriptions.Remove(subscription);
                    continue;
                }
                try
                {
                    ++notifiedSubscrberCount;
                    subscription.Notify();
                }
                catch (Exception exception)
                {
                    Debug.Log($"{ exception }");
                }
            }

            if (notifiedSubscrberCount == 0)
            {
                return;
            }
            Debug.Log($"/{ binaryConfigId }/ { notifiedSubscrberCount } subscribers notified about update");
        }

        private static BinaryConfigId[] GetBinaryConfigIds()
        {
            return Enum.GetValues(typeof(BinaryConfigId)).Cast<BinaryConfigId>().ToArray();
        }

        private static string GetCachedConfigFileName(BinaryConfigId binaryConfigId)
        {
            return $"{ Application.persistentDataPath }/{ GetBinaryConfigFileName(binaryConfigId) }";
        }

        private void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;
            foreach (var key in _updateSubscriptionHashSetByBinaryConfigId.Keys)
            {
                _updateSubscriptionHashSetByBinaryConfigId[key].Clear();
            }
            _tokenSource.Cancel();
        }

        public static string GetBinaryConfigName(BinaryConfigId binaryConfigId)
        {
            return $"{binaryConfigId.ToString().ToLower()}Config";
        }

        public static string GetBinaryConfigFileName(BinaryConfigId binaryConfigId)
        {
            return $"{GetBinaryConfigName(binaryConfigId)}.bytes";
        }

        #region IBinaryConfigManager

        BinaryConfigId[] IBinaryConfigManager.ConfigIds => _configIds;

        IBinaryConfig IBinaryConfigManager.GetConfig(BinaryConfigId binaryConfigId)
        {
            return GetConfig(binaryConfigId);
        }

        Task<bool> IBinaryConfigManager.LoadLocal(bool cached, CancellationToken token)
        {
            return LoadLocalAsync(cached, token);
        }

        IHandle IBinaryConfigManager.SubscribeToUpdate(BinaryConfigId binaryConfigId, Action onConfigUpdate)
        {
            return SubscribeToUpdate(binaryConfigId, onConfigUpdate);
        }

        #endregion

        #region IDisposable

        void IDisposable.Dispose()
        {
            Dispose();
        }

        #endregion
    }
}