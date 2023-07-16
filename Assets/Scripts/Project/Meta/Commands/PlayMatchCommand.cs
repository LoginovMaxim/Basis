using System;
using Project.App.Services;
using Project.Meta.UI.Main;

namespace Project.Meta.Commands
{
    public sealed class PlayMatchCommand : IDisposable
    {
        private readonly MainScreenViewModel _mainScreenViewModel;
        private readonly IMatchSceneLoader _matchSceneLoader;
        
        public PlayMatchCommand(MainScreenViewModel mainScreenViewModel, IMatchSceneLoader matchSceneLoader)
        {
            _mainScreenViewModel = mainScreenViewModel;
            _matchSceneLoader = matchSceneLoader;
            
            _mainScreenViewModel.OnPlayMatchButtonClicked += PlayMatch;
        }

        private void PlayMatch()
        {
            _matchSceneLoader.Load();
        }

        public void Dispose()
        {
            _mainScreenViewModel.OnPlayMatchButtonClicked -= PlayMatch;
        }
    }
}