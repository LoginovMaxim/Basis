using System.Collections.Generic;
using Basis.App.Assemblers;
using UnityEngine;

namespace Basis.App.UI.Splashes
{
    public class Splash<TSplashViewModel> : ISplash where TSplashViewModel : SplashViewModel
    {
        protected readonly TSplashViewModel _splashViewModel;
        protected readonly List<IAssembler> _assemblers;
        
        private float _previousLoadingProgress;

        protected Splash(TSplashViewModel splashViewModel)
        {
            _splashViewModel = splashViewModel;
            _assemblers = new List<IAssembler>();
        }

        public virtual void Show()
        {
            if (_splashViewModel.IsActive)
            {
                return;
            }
            
            _splashViewModel.Progress = 0;
            _previousLoadingProgress = 0;
            
            _splashViewModel.Show();
        }

        public virtual void Hide()
        {
            _splashViewModel.Hide();
            
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
            _splashViewModel.Progress = loadingProgress;
        }
    }
}