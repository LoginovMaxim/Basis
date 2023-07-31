using System;
using UnityEngine;

namespace Basis.Ecs
{
    public sealed class EngineApi : IEngineApi, IDisposable
    {
        public float DeltaTime => _scale * Time.deltaTime;
        private float _scale = 1;

        public void Dispose()
        {
        }
    }
}