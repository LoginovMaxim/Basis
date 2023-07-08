using UnityEngine;

namespace Basis.App.Views
{
    public interface IViewObject
    {
        Transform Transform { get; }
        void OnReinitialized();
        void OnDespawned();
    }
}