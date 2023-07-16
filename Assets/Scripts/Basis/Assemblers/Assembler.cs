using System;
using System.Collections.Generic;
using System.Threading;
using Basis.Assemblers.Launchers;
using Basis.UI.Splashes;
using Basis.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Basis.Assemblers
{
    public abstract class Assembler : IAssembler, IInitializable, IDisposable
    {
        private readonly Queue<IAssemblerLauncher> _assemblerLaunchers = new();
        private readonly CancellationTokenSource _tokenSource = new();
        
        protected readonly ISplash _splash;

        public event Action<float> OnStepLoaded;
        public int ServicesCount { get; private set; }
        public int CurrentStepCount { get; private set; }
        public float Progress { get; private set; }
        public bool Launched { get; private set; }

        protected Assembler(List<IAssemblerLauncher> assemblerParts, ISplash splash)
        {
            _splash = splash;
            
            foreach (var assemblerPart in assemblerParts)
            {
                _assemblerLaunchers.Enqueue(assemblerPart);
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
            await UniTask.Delay(100, cancellationToken: _tokenSource.Token);
            OnStartAssembly();
            
            ServicesCount = _assemblerLaunchers.Count;
            while (_assemblerLaunchers.Count > 0)
            {
                if (_tokenSource.IsCancellationRequested)
                {
                    return;
                } 
                
                var assemblerLauncher = _assemblerLaunchers.Peek();
                try
                {
                    Debug.Log($"Launching service: {assemblerLauncher.GetType()}");
                    await assemblerLauncher.Launch(_tokenSource.Token);
                
                    CurrentStepCount++;
                    Progress = (float) CurrentStepCount / ServicesCount;
                
                    OnStepLoaded?.Invoke(Progress);
                    
                    await UniTask.Delay(200, cancellationToken: _tokenSource.Token);
                }
                catch (Exception e)
                {
                    _tokenSource.Cancel();
                    throw new Exception(
                        $"Service {assemblerLauncher.GetType()} was error launch.".WithColor(LoggerColor.Red) +
                        $"\nMessage {e.Message}." +
                        $"\nStacktrace: {e.StackTrace}.");
                }
                
                _assemblerLaunchers.Dequeue();
                Debug.Log($"Service: {assemblerLauncher.GetType()} launched successfully".WithColor(LoggerColor.Green));
            }
                
            Progress = 1f;
            OnStepLoaded?.Invoke(Progress);
            
            await UniTask.Delay(300, cancellationToken: _tokenSource.Token);
            OnFinishAssembly();
            Launched = true;
        }

        public void Dispose()
        {
            _tokenSource.Cancel();
        }
    }
}