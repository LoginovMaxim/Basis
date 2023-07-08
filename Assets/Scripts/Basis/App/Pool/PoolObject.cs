using Basis.App.Views;
using UnityEngine;

namespace Basis.App.Pool
{
    public abstract class PoolObject : MonoBehaviour, IViewObject
    {
        public Transform Transform => transform;
        
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