using System;
using System.Reflection;
using Bindings;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.Events;
using UnityWeld.Binding;
using UnityWeld.Binding.Internal;
using UnityWeld_Editor;

namespace Editor.Bindings
{
    [CustomEditor(typeof(IntConditionToToggleActiveBinding))]
    public class IntConditionToToggleActiveBindingEditor : BaseBindingEditor
    {
        private IntConditionToToggleActiveBinding _targetScript;
        private AnimBool _viewAdapterOptionsFade;
        private bool _viewAdapterPrefabModified;
        private bool _viewAdapterOptionsPrefabModified;
        private bool _viewModelPropertyPrefabModified;
        private bool _intValueModified;
        

        private void OnEnable()
        {
            _targetScript = (IntConditionToToggleActiveBinding) target;
            _viewAdapterOptionsFade =
                new AnimBool(ShouldShowAdapterOptions(_targetScript.ViewAdapterTypeName,
                    out var adapterType));
            _viewAdapterOptionsFade.valueChanged.AddListener(new UnityAction(((BaseBindingEditor) this).Repaint));
        }

        private void OnDisable()
        {
            _viewAdapterOptionsFade.valueChanged.RemoveListener(new UnityAction(((BaseBindingEditor) this).Repaint));
        }

        public override void OnInspectorGUI()
        {
            if (CannotModifyInPlayMode())
                GUI.enabled = false;
            UpdatePrefabModifiedProperties();
            FontStyle fontStyle = EditorStyles.label.fontStyle;
            Type viewPropertyType = typeof(int);
            string[] adapterTypeNames = GetAdapterTypeNames((Func<Type, bool>) (type =>
                TypeResolver.FindAdapterAttribute(type).OutputType == viewPropertyType));
            
            EditorStyles.label.fontStyle = _viewAdapterPrefabModified ? FontStyle.Bold : fontStyle;
            ShowAdapterMenu(
                new GUIContent("View adapter", "Adapter that converts values sent from the view-model to the view."),
                adapterTypeNames, _targetScript.ViewAdapterTypeName, (Action<string>) (newValue =>
                {
                    if (newValue != _targetScript.ViewAdapterTypeName)
                    {
                        Undo.RecordObject((UnityEngine.Object) _targetScript, "Set view adapter options");
                        _targetScript.ViewAdapterOptions = (AdapterOptions) null;
                    }

                    UpdateProperty<string>(
                        (Action<string>) (updatedValue => _targetScript.ViewAdapterTypeName = updatedValue),
                        _targetScript.ViewAdapterTypeName, newValue, "Set view adapter");
                }));
            
            _viewAdapterOptionsFade.target =
                ShouldShowAdapterOptions(_targetScript.ViewAdapterTypeName, out var adapterType);
            EditorStyles.label.fontStyle = _viewAdapterOptionsPrefabModified ? FontStyle.Bold : fontStyle;
            ShowAdapterOptionsMenu("View adapter options", adapterType,
                (Action<AdapterOptions>) (options => _targetScript.ViewAdapterOptions = options),
                _targetScript.ViewAdapterOptions, _viewAdapterOptionsFade.faded);
            EditorGUILayout.Space();
            EditorStyles.label.fontStyle = _viewModelPropertyPrefabModified ? FontStyle.Bold : fontStyle;
            Type adaptedViewPropertyType =
                AdaptTypeBackward(viewPropertyType, _targetScript.ViewAdapterTypeName);
            
            ShowViewModelPropertyMenu(
                new GUIContent("View-model property", "Property on the view-model to bind to."),
                TypeResolver.FindBindableProperties((AbstractMemberBinding) _targetScript),
                (Action<string>) (updatedValue => _targetScript.ViewModelPropertyName = updatedValue),
                _targetScript.ViewModelPropertyName,
                (Func<PropertyInfo, bool>) (property => property.PropertyType == adaptedViewPropertyType));
            EditorStyles.label.fontStyle = fontStyle;
            
            EditorGUILayout.Space();
            EditorStyles.label.fontStyle = _intValueModified ? FontStyle.Bold : fontStyle;
            var value = EditorGUILayout.IntField(
                new GUIContent("Int value for activate", "GameObject and its children will become active if binding value is checked by ConditionChecker, and inactive if not"),
                _targetScript.IntTriggerToActive);
            if (value != _targetScript.IntTriggerToActive)
            {
                _targetScript.IntTriggerToActive = value;
                _intValueModified = true;
            }

            EditorStyles.label.fontStyle = _intValueModified ? FontStyle.Bold : fontStyle;
            var valueCondition = EditorGUILayout.EnumPopup(
                new GUIContent("Int Condition Check value for activate", "GameObject and its children will become active if binding value is checked by ConditionChecker, and inactive if not"),
                _targetScript.ConditionChecker);

            if ((IntConditionToToggleActiveBinding.Condition)valueCondition != _targetScript.ConditionChecker)
            {
                _targetScript.ConditionChecker = (IntConditionToToggleActiveBinding.Condition)valueCondition ;
                _intValueModified = true;
            }
            
            EditorStyles.label.fontStyle = fontStyle;
            
            
        }

        private void UpdatePrefabModifiedProperties()
        {
            SerializedProperty iterator = serializedObject.GetIterator();
            iterator.Next(true);
            do
            {
                switch (iterator.name)
                {
                    case "viewAdapterTypeName":
                        _viewAdapterPrefabModified = iterator.prefabOverride;
                        break;

                    case "viewAdapterOptions":
                        _viewAdapterOptionsPrefabModified = iterator.prefabOverride;
                        break;

                    case "viewModelPropertyName":
                        _viewModelPropertyPrefabModified = iterator.prefabOverride;
                        break;
                    
                    case "intTriggerToActive":
                        _intValueModified = iterator.prefabOverride;
                        break;
                }
            } while (iterator.Next(false));
        }
    }
}