﻿using Leopotam.Ecs;
using UnityEngine;

namespace Ecs
{
    public abstract class MonoLinkBase : MonoBehaviour
    {
        public abstract void Make(ref EcsEntity entity);
    }
}