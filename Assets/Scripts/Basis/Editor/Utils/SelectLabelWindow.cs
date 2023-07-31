using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Basis.Configs;
using Basis.Localizations;
using Basis.ResourceProviders;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Basis.Editor.Utils
{
    public class SelectLabelWindow : EditorWindow
    {
        private IBinaryConfigManager _binaryConfigManager;
        private ILocalization _localization;
        private ILocalizationBinding _target;
        public string Filter;
        private Vector2 _scrollPosition;

        public static async void Select(ILocalizationBinding target)
        {
            var window = GetWindow<SelectLabelWindow>();
            window._target = target;
            window._localization = new Localization();
            window.Show(true);

            window._binaryConfigManager = new BinaryConfigManager(new ResourceProvider());
            await window._binaryConfigManager.LoadLocalAsync(true, new CancellationToken());
            
            var localizationConfig = window._binaryConfigManager.GetConfig(BinaryConfigId.Localization);
            var entity = localizationConfig.GetEntity<LocalizationConfigEntity>(LocalizationConfigEntity.InstanceId);

            window._localization.InitializeLocalizationTable(entity.ToTables());
        }

        private void OnFocus()
        {
            GUI.FocusControl("Filter");
        }

        private void OnGUI()
        {
            if (_localization.Table == null)
            {
                return;
            }
            
            GUI.SetNextControlName("Filter");
            Filter = EditorGUILayout.TextField("Filter:", Filter);
            if (string.IsNullOrEmpty(Filter))
            {
                DrawKeys(_localization.Keys);
            }
            else
            {
                var regex = new Regex(Filter, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                DrawKeys(_localization.Keys.Where(key => regex.IsMatch(key)));
            }
            
            GUI.FocusControl("Filter");
        }

        private void DrawKeys(IEnumerable<string> keys)
        {
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, false, true);
            foreach (var key in keys)
            {
                if (!GUILayout.Button(key))
                    continue;
                
                var changed = _target.LocalizationKey != key;
                if (changed)
                {
                    _target.LocalizationKey = key;

                    EditorSceneManager.MarkSceneDirty(((MonoBehaviour) _target).gameObject.scene);
                    PrefabUtility.RecordPrefabInstancePropertyModifications(((MonoBehaviour) _target));   
                }
                
                Close();
                return;
            }
            EditorGUILayout.EndScrollView();
        }
    }
}