using System;
using System.Collections.Generic;
using System.Threading;
using Basis.Assemblers;
using Basis.SceneLoaders;
using Project.App.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Basis.UI.Splashes
{
    public class Splash : ISplash
    {
        public event Action<float> OnLoadProgressChanged;
        
        private readonly ISceneLoader _sceneLoader;
        private readonly List<IAssembler> _assemblers;
        
        private float _previousLoadingProgress;
        private bool _isShowing;

        protected Splash(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _assemblers = new List<IAssembler>();
        }

        public virtual async void Show()
        {
            if (_isShowing)
            {
                return;
            }
            
            _isShowing = true;
            _previousLoadingProgress = 0;
            
            await _sceneLoader.LoadSceneAsync(
                Constants.LoadingSplashBundleKeys.LoadingSplashKey,
                true,
                LoadSceneMode.Additive,
                new CancellationToken());
        }

        public virtual async void Hide()
        {
            await _sceneLoader.UnloadSceneAsync(Constants.LoadingSplashBundleKeys.LoadingSplashKey, new CancellationToken());
            
            _assemblers.ForEach(assembler => assembler.OnStepLoaded -= OnStepLoad);
            _assemblers.Clear();
            
            _isShowing = false;
        }

        public void AddAssembler(IAssembler assembler)
        {
            if (_assemblers.Contains(assembler))
            {
                return;
            }
            
            assembler.OnStepLoaded += OnStepLoad;
            _assemblers.Add(assembler);
        }

        private void OnStepLoad(float progress)
        {
            var loadingProgress = 0f;
            foreach (var appAssembler in _assemblers)
            {
                loadingProgress += appAssembler.Progress;
            }
            
            loadingProgress /= _assemblers.Count;
            loadingProgress = Mathf.Clamp(loadingProgress, _previousLoadingProgress, 1f);
            
            _previousLoadingProgress = loadingProgress;
            OnLoadProgressChanged?.Invoke(loadingProgress);
            //_splashViewModel.Progress = loadingProgress;
        }
    }
}