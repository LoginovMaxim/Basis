using UnityEngine;

namespace Basis.UI.Screens
{
    public interface IScreenViewModel
    {
        RectTransform RectTransform { get; }
        CanvasGroup CanvasGroup { get; }
        void SetActive(bool isActive);
    }
}