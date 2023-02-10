using System;
using App.Localizations;
using Bindings;
using Editor.Utils;
using UnityEditor;
using UnityEngine;
using UnityWeld.Binding;
using UnityWeld.Binding.Internal;
using UnityWeld_Editor;
using Object = UnityEngine.Object;

namespace Editor.Bindings
{
    [CustomEditor(typeof (LocalizationBinding))]
    public class LocalizationBindingEditor : BaseBindingEditor
    {
        private LocalizationBinding targetScript;
        private bool viewModelPropertyPrefabModified;
        private bool viewPropertyPrefabModified;

        private void OnEnable()
        {
            targetScript = (LocalizationBinding) target;
        }

        public override void OnInspectorGUI()
        {
            if (CannotModifyInPlayMode())
            {
                GUI.enabled = false;
            }
            
            DrawLocalizationKey(target);
            UpdatePrefabModifiedProperties();
            
            FontStyle fontStyle = EditorStyles.label.fontStyle;
            EditorStyles.label.fontStyle = viewPropertyPrefabModified ? FontStyle.Bold : fontStyle;
            bool enabled = GUI.enabled;
            
            EditorGUILayout.Space();
            
            EditorStyles.label.fontStyle = viewModelPropertyPrefabModified ? FontStyle.Bold : fontStyle;
            Type adaptedViewPropertyType = typeof(object);

            for (var index = 0; index < targetScript.ViewModelProperties.Count; index++)
            {
                var index1 = index;
                ShowViewModelPropertyMenu(
                    new GUIContent("View-model property", "Property on the view-model to bind to."),
                    TypeResolver.FindBindableProperties(targetScript),
                    updatedValue => targetScript.ViewModelProperties[index1] = updatedValue,
                    targetScript.ViewModelProperties[index1],
                    property => typeof(object).IsAssignableFrom(property.PropertyType));
            }

            EditorGUILayout.BeginHorizontal();
            
            if (GUILayout.Button("Add"))
            {
                targetScript.ViewModelProperties.Add(string.Empty);
            }
            if (targetScript.ViewModelProperties.Count > 0 && GUILayout.Button("Remove"))
            {
                targetScript.ViewModelProperties.RemoveAt(targetScript.ViewModelProperties.Count - 1);
            }
            
            EditorGUILayout.EndHorizontal();

            GUI.enabled = enabled;
            EditorStyles.label.fontStyle = fontStyle;
        }

        private void UpdatePrefabModifiedProperties()
        {
            SerializedProperty iterator = serializedObject.GetIterator();
            iterator.Next(true);
            do
            {
                string name = iterator.name;
                if (!(name == "viewModelPropertyName"))
                {
                    if (name == "viewPropertyName")
                        viewPropertyPrefabModified = iterator.prefabOverride;
                }
                else
                    viewModelPropertyPrefabModified = iterator.prefabOverride;
            } while (iterator.Next(false));
        }
        
        public static void DrawLocalizationKey(Object target)
        {
            var text = ((ILocalizationMonoBehaviour) target);
            if (GUILayout.Button($"Localization: {text.LocalizationKey}"))
                SelectLabelWindow.Select(text);
        }
    }
}