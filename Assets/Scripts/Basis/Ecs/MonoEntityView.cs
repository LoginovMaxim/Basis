using UnityEngine;

namespace Basis.Ecs
{
    public abstract class MonoEntityView : MonoBehaviour
    {
        public MonoEntity MonoEntity => _monoEntity;
        public GameObject ToggleGameObject => _toggleGameObject;
        
        [SerializeField] private MonoEntity _monoEntity;
        [SerializeField] private GameObject _toggleGameObject;
    }
}