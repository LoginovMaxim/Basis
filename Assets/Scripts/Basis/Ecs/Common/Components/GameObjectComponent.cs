using System;
using UnityEngine;

namespace Basis.Ecs.Common.Components
{
    [Serializable] public struct GameObjectComponent
    {
        public GameObject GameObject;
        public int Layer;
    }
}
