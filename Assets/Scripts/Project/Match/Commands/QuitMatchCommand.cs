using System;
using Project.App.Services;
using Project.Match.UI.Gameplay;

namespace Project.Match.Commands
{
    public sealed class QuitMatchCommand : IDisposable
    {
        private readonly GameplayScreenViewModel _gameplayScreenViewModel;
        private readonly IMetaSceneLoader _metaSceneLoader;

        public QuitMatchCommand(GameplayScreenViewModel gameplayScreenViewModel, IMetaSceneLoader metaSceneLoader)
        {
            _gameplayScreenViewModel = gameplayScreenViewModel;
            _metaSceneLoader = metaSceneLoader;
            
            _gameplayScreenViewModel.OnQuitMatchButtonClicked += QuitMatch;
        }

        private void QuitMatch()
        {
            _metaSceneLoader.Load();
        }

        public void Dispose()
        {
            _gameplayScreenViewModel.OnQuitMatchButtonClicked -= QuitMatch;
        }
    }
}