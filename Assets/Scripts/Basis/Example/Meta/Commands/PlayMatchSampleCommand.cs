using Azur.TowerDefense.App.UI.Splashes;
using Basis.App.Monos;
using Basis.App.UI.Splashes;
using Basis.Example.App.Commands;
using Basis.Example.Meta.Signals;
using UnityEngine.SceneManagement;
using Zenject;

namespace Basis.Example.Meta.Commands
{
    public class PlayMatchSampleCommand : Command
    {
        private const string SampleMatchScenePath = "Example/Scenes/MatchExample";
        
        private readonly ISceneLoader _sceneLoader;
        private readonly IAppSplash _appSplash;
        
        public PlayMatchSampleCommand(ISceneLoader sceneLoader, IAppSplash appSplash, SignalBus signalBus) : base(signalBus)
        {
            _sceneLoader = sceneLoader;
            _appSplash = appSplash;
        }

        private void OnPlayMatch()
        {
            _appSplash.Show();
            _sceneLoader.LoadScene(SampleMatchScenePath, LoadSceneMode.Single, null);
        }
        
        protected override void Subscribe()
        {
            _signalBus.Subscribe<PlayMatchSampleSignal>(OnPlayMatch);
        }

        protected override void Unsubscribe()
        {
            _signalBus.Unsubscribe<PlayMatchSampleSignal>(OnPlayMatch);
        }
    }
}