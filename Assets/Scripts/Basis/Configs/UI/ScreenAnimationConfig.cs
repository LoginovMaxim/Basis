using DG.Tweening;
using UnityEngine;

namespace Basis.Configs.UI
{
    [CreateAssetMenu(fileName = "ScreenAnimationConfig", menuName = "Project/App/ScreenAnimationConfig", order = 1)]
    public sealed class ScreenAnimationConfig : ScriptableObject, IScreenAnimationConfig
    {
        [Space]
        [Min(0)]
        [SerializeField] private float _showingFadeDuration;
        [SerializeField] private Ease _showingFadeEase;
        
        [Space]
        [Min(0)]
        [SerializeField] private float _hidingFadeDuration;
        [SerializeField] private Ease _hidingFadeEase;

        [Space]
        [Min(0)]
        [SerializeField] private float _showingMoveDuration;
        [SerializeField] private Ease _showingMoveEase;
        
        [Space]
        [Min(0)]
        [SerializeField] private float _hidingMoveDuration;
        [SerializeField] private Ease _hidingMoveEase;

        public float ShowingFadeDuration => _showingFadeDuration;
        public Ease ShowingFadeEase => _showingFadeEase;
        public float HidingFadeDuration => _hidingFadeDuration;
        public Ease HidingFadeEase => _hidingFadeEase;
        public float ShowingMoveDuration => _showingMoveDuration;
        public Ease ShowingMoveEase => _showingMoveEase;
        public float HidingMoveDuration => _hidingMoveDuration;
        public Ease HidingMoveEase => _hidingMoveEase;
    }
}