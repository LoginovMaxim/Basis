﻿using UnityEngine;

namespace Basis.Monos
{
    public interface IGameObjectFinder
    {
        T GetGameObject<T>() where T : MonoBehaviour;
        T[] GetGameObjects<T>() where T : MonoBehaviour;
    }
}