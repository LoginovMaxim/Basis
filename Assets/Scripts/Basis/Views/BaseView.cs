using UnityEngine;

namespace Basis.Views
{
    public abstract class BaseView : MonoBehaviour, IViewObject
    {
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
        
        public Quaternion Rotation
        {
            get => transform.rotation;
            set => transform.rotation = value;
        }
        
        public Vector3 RotationEuler
        {
            get => transform.rotation.eulerAngles;
            set => transform.rotation = Quaternion.Euler(value);
        }
        
        public Vector3 LocalScale
        {
            get => transform.localScale;
            set => transform.localScale = value;
        }

        public virtual void OnReinitialized()
        {
            gameObject.SetActive(true);
        }

        public virtual void OnDespawned()
        {
            gameObject.SetActive(false);
        }
    }
}