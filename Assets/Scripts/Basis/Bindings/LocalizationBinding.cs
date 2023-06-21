using System;
using System.Collections.Generic;
using System.Linq;
using Basis.App.Localizations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityWeld.Binding;
using UnityWeld.Binding.Internal;
using Zenject;

namespace Basis.Bindings
{
    public sealed class LocalizationBinding : AbstractMemberBinding, ILocalizationMonoBehaviour
    {
        [SerializeField] private string _localizationKey = "{0}";
        [SerializeField] private List<string> _viewModelPropertyName = new List<string>();

        private ILocalization _localization;
        private object[] _localized;
        private List<PropertyEndPoint> _sources;
        private Component _view;
        private PropertyWatcher[] _viewModelWatchers;
        private PropertyEndPoint _viewProperty;
        private bool _connected;
        
        public List<string> ViewModelProperties => _viewModelPropertyName;
        public string LocalizationKey
        {
            get => _localizationKey;
            set => _localizationKey = value;
        }

        [Inject]
        public void Init(ILocalization localization)
        {
            _localization = localization;
        }

        public override void Connect()
        {
            try
            {
                _localization.OnLanguageChanged += UpdateLocalization;

                Type targetType;
                if (GetComponent<Text>() != null)
                {
                    targetType = typeof(Text);
                }
                else if (GetComponent<TextMeshProUGUI>() != null)
                {
                    targetType = typeof(TextMeshProUGUI);
                }
                else
                {
                    throw new NotSupportedException("Localization binding should be on Text or TextmeshPro component");
                }

                ParseViewEndPointReference(targetType.FullName + ".text", out var memberName, out _view);

                _sources = _viewModelPropertyName.Select(u => MakeViewModelEndPoint(u, null, null)).ToList();
                _viewProperty = new PropertyEndPoint(_view, memberName, null, null, "view", this);

                _viewModelWatchers = _sources.Select(source => source.Watch(UpdateLocalization)).ToArray();
                _localized = _sources.ConvertAll(s => s.GetValue() ?? string.Empty).ToArray();
                _connected = true;

                UpdateLocalization();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Debug.LogError($"Localization binding error on '{name}': {e}");
                Disconnect();
            }
        }

        private void Sync()
        {
            try
            {
                if (!_connected)
                {
                    return;
                }

                if (_view == null)
                {
                    return;
                }

                if (_sources.Count == 0)
                {
                    _viewProperty.SetValue(_localization.GetString(_localizationKey));
                    return;
                }

                for (var i = 0; i < _sources.Count; i++)
                {
                    try
                    {
                        var value = _sources[i]?.GetValue() ?? _localized[i];
                        _localized[i] = value is string text ? _localization.GetString(text) : value;
                    }
                    catch (Exception exception)
                    {
                        _localized[i] = "<type_cast>";
                        Debug.LogError(exception);
                    }
                }

                var resultText = _localization.GetString(_localizationKey, _localized);
                _viewProperty.SetValue(resultText);
            }
            catch (Exception e)
            {
                Debug.LogWarning($"LocalizationException Locale = {_localization.Language}; Key = {_localizationKey}");

                foreach (var source in _sources)
                {
                    Debug.LogWarning($"Source type = {source.GetType()}, source value = {source.GetValue()}");
                }

                Debug.LogException(e);
                Disconnect();
            }
        }

        public override void Disconnect()
        {
            if (_connected)
            {
                _localization.OnLanguageChanged -= UpdateLocalization;
            }

            _connected = false;
            if (_viewModelWatchers == null)
            {
                return;
            }

            foreach (var watcher in _viewModelWatchers)
            {
                watcher.Dispose();
            }

            _viewModelWatchers = null;
            _localization.OnLanguageChanged = null;
        }

        private void UpdateLocalization()
        {
            Sync();
        }
    }
}