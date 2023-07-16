using System;
using System.Collections.Generic;
using Basis.Assemblers;
using Basis.SceneLoaders;
using Basis.Utils;
using Cysharp.Threading.Tasks;
using Project.App.Data;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Basis.UI.Splashes
{
    public class Splash : ISplash
    {
        public event Action<float> OnLoadProgressChanged;
        
        private readonly IAddressableSceneLoader _addressableSceneLoader;
        private readonly List<IAssembler> _assemblers;

        private AsyncOperationHandle<SceneInstance> _asyncOperationHandle;
        private float _previousLoadingProgress;
        private bool _isShowing;

        protected Splash(IAddressableSceneLoader addressableSceneLoader)
        {
            _addressableSceneLoader = addressableSceneLoader;
            _assemblers = new List<IAssembler>();
        }

        public virtual async UniTask Show()
        {
            if (_isShowing)
            {
                return;
            }
            
            _isShowing = true;
            _previousLoadingProgress = 0;
            
            _asyncOperationHandle = await _addressableSceneLoader.LoadSceneAsync(
                Constants.LoadingSplashBundleKeys.LoadingSplashKey,
                LoadSceneMode.Additive,
                true,
                false);
            
            _isShowing = false;
        }

        public virtual async UniTask Hide()
        {
            if (_isShowing)
            {
#if DEBUG
                Debug.Log($"[{nameof(Splash)}] Can't hide splash when active showing".WithColor(Color.yellow));
#endif
                return;
            }
            
            await _addressableSceneLoader.UnloadSceneAsync(_asyncOperationHandle);
            
            _assemblers.ForEach(assembler => assembler.OnStepLoaded -= OnStepLoad);
            _assemblers.Clear();
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