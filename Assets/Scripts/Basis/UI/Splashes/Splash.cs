using System.Collections.Generic;
using Project.App.UI.Splashes;
using UnityEngine;

namespace Basis.UI.Splashes
{
    public class Splash : ISplash
    {
        private readonly LoadingSplashViewModel _loadingSplashViewModel;
        private readonly List<IProgress> _progresses;

        private float _previousLoadingProgress;

        protected Splash(LoadingSplashViewModel addressableSceneLoader)
        {
            _loadingSplashViewModel = addressableSceneLoader;
            _progresses = new List<IProgress>();
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

        public void AddProgressService(IProgress progress)
        {
            if (_progresses.Contains(progress))
            {
                return;
            }
            
            progress.OnProgressChanged += HandleChangeProgress;
            _progresses.Add(progress);
        }

        private void HandleChangeProgress(float progress)
        {
            var loadingProgress = 0f;
            foreach (var appAssembler in _progresses)
            {
                loadingProgress += appAssembler.Progress;
            }
            
            loadingProgress /= _progresses.Count;
            loadingProgress = Mathf.Clamp(loadingProgress, _previousLoadingProgress, 1f);
            
            _loadingSplashViewModel.Progress = loadingProgress;
            _previousLoadingProgress = loadingProgress;

            TryHide();
        }

        private void TryHide()
        {
            foreach (var progress in _progresses)
            {
                if (progress.Progress < 1f)
                {
                    return;
                }
            }
            
            _progresses.ForEach(assembler => assembler.OnProgressChanged -= HandleChangeProgress);
            _progresses.Clear();
            
            _loadingSplashViewModel.Hide();
        }
    }
}