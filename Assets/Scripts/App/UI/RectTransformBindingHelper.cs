using UnityEngine;
using UnityWeld.Binding;

namespace App.UI
{
    [RequireComponent(typeof(Template))]
    [RequireComponent(typeof(RectTransform))]
    public sealed class RectTransformBindingHelper : MonoBehaviour
    {
        private void Awake()
        {
            var template = GetComponent<Template>();
            var rectTransformViewModel = (IRectTransformViewModel) template.GetViewModel();
            
            var rect = GetComponent<RectTransform>();
            rectTransformViewModel.RectTransform = rect;
        }
    }
}