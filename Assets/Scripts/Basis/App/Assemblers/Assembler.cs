using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Basis.Utils;
using UnityEngine;

namespace Basis.App.Assemblers
{
    public abstract class Assembler : IAssembler, IDisposable
    {
        private readonly Queue<IAssemblerPart> _assemblerParts = new();
        private readonly CancellationTokenSource _tokenSource = new();

        public event Action<float> OnStepLoaded;
        public int ServicesCount { get; private set; }
        public int CurrentStepCount { get; private set; }
        public float Progress { get; private set; }

        protected Assembler(List<IAssemblerPart> assemblerParts)
        {
#pragma warning disable CS4014
            LaunchAssemblerPartsAsync(assemblerParts);
#pragma warning restore CS4014
        }

        protected abstract void OnStartAssembly();
        
        protected abstract void OnFinishAssembly();

        private async Task LaunchAssemblerPartsAsync(List<IAssemblerPart> assemblerParts)
        {
            await Task.Delay(100);

            OnStartAssembly();
            
            foreach (var assemblerPart in assemblerParts)
            {
                _assemblerParts.Enqueue(assemblerPart);
            }
            
            ServicesCount = _assemblerParts.Count;
            while (_assemblerParts.Count > 0)
            {
                if (_tokenSource.IsCancellationRequested)
                {
                    return;
                } 
                
                var assemblerPart = _assemblerParts.Peek();
                try
                {
                    Debug.Log($"Launching service: {assemblerPart.GetType()}");
                    await assemblerPart.Launch();
                }
                catch (Exception e)
                {
                    _tokenSource.Cancel();
                    throw new Exception(
                        $"Service {assemblerPart.GetType()} was error launch.".WithColor(LoggerColor.Red) +
                        $"\nMessage {e.Message}." +
                        $"\nStacktrace: {e.StackTrace}.");
                }
                
                _assemblerParts.Dequeue();
                CurrentStepCount++;
                Progress = (float) CurrentStepCount / ServicesCount;
                OnStepLoaded?.Invoke(Progress);
                Debug.Log($"Service: {assemblerPart.GetType()} launched successfully".WithColor(LoggerColor.Green));
            }

            OnFinishAssembly();
        }

        public void Dispose()
        {
            _tokenSource.Cancel();
        }
    }
}