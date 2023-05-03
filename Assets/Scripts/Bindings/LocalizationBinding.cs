using System;
using System.Collections.Generic;
using System.Linq;
using App.Localizations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityWeld.Binding;
using UnityWeld.Binding.Internal;

namespace Bindings
{
    public sealed class LocalizationBinding : AbstractMemberBinding, ILocalizationMonoBehaviour
    {
        [SerializeField] private string _localizationKey = "{0}";
        [SerializeField] private List<string> _viewModelPropertyName = new List<string>();
        private PropertyWatcher[] _viewModelWatchers;
        private Action _sync;
        private object[] _localized;

        private ILocalization _localization => Localization.Instance;
        
        public List<string> ViewModelProperties => _viewModelPropertyName;

        public string LocalizationKey
        {
            get => _localizationKey;
            set => _localizationKey = value;
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
                
                ParseViewEndPointReference(targetType.FullName + ".text", out var memberName, out var view);
            
                var sources = _viewModelPropertyName.Select(u => MakeViewModelEndPoint(u, null, null)).ToList();
                var viewProperty = new PropertyEndPoint(view, memberName, null, null, "view", this);
            
                _viewModelWatchers = sources.Select(source => source.Watch(UpdateLocalization)).ToArray();
                _localized = sources.ConvertAll(s => s.GetValue() ?? string.Empty).ToArray();
                _sync = () =>
                {
                    try
                    {
                        if (sources.Count == 0)
                        {
                            viewProperty.SetValue(_localization?.GetString(_localizationKey));
                        }
                        else
                        {
                            /*for (int i = 0; i < sources.Count; i++)
                            {
                                var value = sources[i]?.GetValue() ?? _localized[i];
                                _localized[i] = value is string text ? _localization.GetString(text) : value;
                            }
                            var resultText = _localization.GetString(_localizationKey, _localized);
                            if(view != null)
                                viewProperty.SetValue(resultText);*/
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogWarning(
                            $"LocalizationException Locale={_localization.Language} Key={_localizationKey} Args='{string.Join(",", _localized.Select(u => u.ToString()))}'");
                        Debug.LogException(e);
                        Disconnect();
                    }
                };
            
            
                UpdateLocalization();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Debug.LogError($"Localization binding error on '{this.name}': {e}");
                Disconnect();
            }
        }

        public override void Disconnect()
        {
            _sync = null;
            
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

        void UpdateLocalization()
        {
            _sync?.Invoke();
        }
    }
}