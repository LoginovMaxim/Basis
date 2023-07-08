using UnityEngine;

namespace Basis.Views
{
    public interface IViewObject
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 RotationEuler { get; set; }
        public Vector3 LocalScale { get; set; }
        
        public void OnReinitialized();
        public void OnDespawned();
    }
}