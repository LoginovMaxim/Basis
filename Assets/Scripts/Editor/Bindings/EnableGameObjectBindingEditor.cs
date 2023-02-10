using System;
using Bindings;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityWeld.Binding.Internal;
using UnityWeld_Editor;

namespace Editor.Bindings
{
    [CustomEditor(typeof(EnableGameObjectBinding))]
    public class EnableGameObjectBindingEditor : BaseBindingEditor
    {
        private EnableGameObjectBinding targetScript;
        private AnimBool viewAdapterOptionsFade;
        private bool viewAdapterPrefabModified;
        private bool viewAdapterOptionsPrefabModified;
        private bool viewModelPropertyPrefabModified;

        private void OnEnable()
        {
            targetScript = (EnableGameObjectBinding) target;
            Type adapterType;
            viewAdapterOptionsFade =
                new AnimBool(ShouldShowAdapterOptions(targetScript.ViewAdapterTypeName, out adapterType));
            viewAdapterOptionsFade.valueChanged.AddListener(Repaint);
        }

        private void OnDisable()
        {
            viewAdapterOptionsFade.valueChanged.RemoveListener(Repaint);
        }

        public override void OnInspectorGUI()
        {
            if (CannotModifyInPlayMode())
                GUI.enabled = false;
            
            UpdatePrefabModifiedProperties();
            FontStyle fontStyle = EditorStyles.label.fontStyle;
            Type viewPropertyType = typeof(bool);
            string[] adapterTypeNames = GetAdapterTypeNames((type =>
                TypeResolver.FindAdapterAttribute(type).OutputType == viewPropertyType));
            EditorStyles.label.fontStyle = viewAdapterPrefabModified ? FontStyle.Bold : fontStyle;
            ShowAdapterMenu(
                new GUIContent("View adapter", "Adapter that converts values sent from the view-model to the view."),
                adapterTypeNames, targetScript.ViewAdapterTypeName, (newValue =>
                {
                    if (newValue != targetScript.ViewAdapterTypeName)
                    {
                        Undo.RecordObject(targetScript, "Set view adapter options");
                        targetScript.ViewAdapterOptions = null;
                    }

                    UpdateProperty(
                        (updatedValue => targetScript.ViewAdapterTypeName = updatedValue),
                        targetScript.ViewAdapterTypeName, newValue, "Set view adapter");
                }));
            Type adapterType;
            viewAdapterOptionsFade.target = ShouldShowAdapterOptions(targetScript.ViewAdapterTypeName, out adapterType);
            EditorStyles.label.fontStyle = viewAdapterOptionsPrefabModified ? FontStyle.Bold : fontStyle;
            ShowAdapterOptionsMenu("View adapter options", adapterType,
                options => targetScript.ViewAdapterOptions = options,
                targetScript.ViewAdapterOptions, viewAdapterOptionsFade.faded);
            EditorGUILayout.Space();
            EditorStyles.label.fontStyle = viewModelPropertyPrefabModified ? FontStyle.Bold : fontStyle;
            Type adaptedViewPropertyType = AdaptTypeBackward(viewPropertyType, targetScript.ViewAdapterTypeName);
            ShowViewModelPropertyMenu(
                new GUIContent("View-model property", "Property on the view-model to bind to."),
                TypeResolver.FindBindableProperties(targetScript),
                (updatedValue => targetScript.ViewModelPropertyName = updatedValue),
                targetScript.ViewModelPropertyName,
                (property => property.PropertyType == adaptedViewPropertyType));
            EditorStyles.label.fontStyle = fontStyle;
        }

        private void UpdatePrefabModifiedProperties()
        {
            SerializedProperty iterator = serializedObject.GetIterator();
            iterator.Next(true);
            do
            {
                string name = iterator.name;
                if (!(name == "viewAdapterTypeName"))
                {
                    if (!(name == "viewAdapterOptions"))
                    {
                        if (name == "viewModelPropertyName")
                            viewModelPropertyPrefabModified = iterator.prefabOverride;
                    }
                    else
                        viewAdapterOptionsPrefabModified = iterator.prefabOverride;
                }
                else
                    viewAdapterPrefabModified = iterator.prefabOverride;
            } while (iterator.Next(false));
        }
    }
}