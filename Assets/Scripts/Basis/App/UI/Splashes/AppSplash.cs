using System.Collections.Generic;
using Basis.App.Assemblers;
using UnityEngine;

namespace Basis.App.UI.Splashes
{
    public sealed class AppSplash : Splash<AppSplashViewModel>, IAppSplash
    {
        private readonly List<IAssembler> _assemblers;
        private float _previousLoadingProgress;
        
        public AppSplash(AppSplashViewModel splashViewModel) : base(splashViewModel)
        {
            _assemblers = new List<IAssembler>();
        }

        public override void Show()
        {
            if (_splashViewModel.IsActive)
            {
                return;
            }
            
            _splashViewModel.Progress = 0;
            _previousLoadingProgress = 0;
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
            _assemblers.ForEach(assembler => assembler.OnStepLoaded -= OnStepLoad);
            _assemblers.Clear();
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

        public void AddAssembler(IAssembler assembler)
        {
            if (_assemblers.Contains(assembler))
            {
                return;
            }
            
            assembler.OnStepLoaded += OnStepLoad;
            _assemblers.Add(assembler);
        }
    }
}