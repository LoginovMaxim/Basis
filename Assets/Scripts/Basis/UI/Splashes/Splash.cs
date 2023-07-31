using System.Collections.Generic;
using Basis.Assemblers;
using Project.App.UI.Splashes;
using UnityEngine;

namespace Basis.UI.Splashes
{
    public class Splash : ISplash
    {
        private readonly LoadingSplashViewModel _loadingSplashViewModel;
        private readonly List<IAssembler> _assemblers;

        private float _previousLoadingProgress;

        protected Splash(LoadingSplashViewModel addressableSceneLoader)
        {
            _loadingSplashViewModel = addressableSceneLoader;
            _assemblers = new List<IAssembler>();
        }

        public virtual void Show()
        {
            if (_loadingSplashViewModel.IsActive)
            {
                return;
            }
            
            _loadingSplashViewModel.Progress = 0;
            _previousLoadingProgress = 0;
            
            _loadingSplashViewModel.Show();
        }

        public virtual void Hide()
        {
            if (_previousLoadingProgress < 1)
            {
                return;
            }
            
            _assemblers.ForEach(assembler => assembler.OnStepLoaded -= OnStepLoad);
            _assemblers.Clear();
            
            _loadingSplashViewModel.Hide();
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
            
            _loadingSplashViewModel.Progress = loadingProgress;
            _previousLoadingProgress = loadingProgress;
        }
    }
}