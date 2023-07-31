using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Basis.UI.Utils
{
    public sealed class ImageSmoothSwitcher : MonoBehaviour
    {
        [SerializeField] private Image[] _images;
        [SerializeField] private float _smooth;

        private Color _targetColor;
        
        private void OnEnable()
        {
            var initialColor = Color.HSVToRGB(Random.Range(0f, 1f), 0.75f, 0.9f);
            foreach (var image in _images)
            {
                image.color = initialColor;
            }
            _targetColor = Color.HSVToRGB(Random.Range(0f, 1f), 0.75f, 0.9f);
        }

        private void Update()
        {
            foreach (var image in _images)
            {
                image.color = Color.Lerp(image.color, _targetColor, _smooth * Time.smoothDeltaTime);
            }
        }
    }
}