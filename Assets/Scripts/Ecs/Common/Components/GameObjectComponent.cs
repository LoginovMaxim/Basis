using System;
using UnityEngine;

namespace Ecs.Common.Components
{
    [Serializable] public struct GameObjectComponent
    {
        public GameObject GameObject;
        public int Layer;
    }
}
