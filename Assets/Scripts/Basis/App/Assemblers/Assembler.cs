using System;
using System.Collections.Generic;
using System.Threading;
using Basis.App.UI.Splashes;
using Basis.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Basis.App.Assemblers
{
    public abstract class Assembler : IAssembler, IInitializable, IDisposable
    {
        private readonly Queue<IAssemblerPart> _assemblerParts = new();
        private readonly CancellationTokenSource _tokenSource = new();
        
        protected readonly ISplash _splash;

        public event Action<float> OnStepLoaded;
        public int ServicesCount { get; private set; }
        public int CurrentStepCount { get; private set; }
        public float Progress { get; private set; }

        protected Assembler(List<IAssemblerPart> assemblerParts, ISplash splash)
        {
            _splash = splash;
            
            foreach (var assemblerPart in assemblerParts)
            {
                _assemblerParts.Enqueue(assemblerPart);
            }
        }

        public async void Initialize()
        {
            _splash.AddAssembler(this);
            await LaunchAssemblerPartsAsync();
        }

        protected abstract void OnStartAssembly();
        
        protected abstract void OnFinishAssembly();

        private async UniTask LaunchAssemblerPartsAsync()
        {
            await UniTask.Delay(100, false, PlayerLoopTiming.Update, _tokenSource.Token);
            OnStartAssembly();
            
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
                    await assemblerPart.Launch(_tokenSource.Token);
                    await UniTask.Delay(100, false, PlayerLoopTiming.Update, _tokenSource.Token);
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
            
            await UniTask.Delay(1000, false, PlayerLoopTiming.Update, _tokenSource.Token);
            OnFinishAssembly();
        }

        public void Dispose()
        {
            _tokenSource.Cancel();
        }
    }
}