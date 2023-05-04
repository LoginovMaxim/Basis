using App.Monos;
using App.UI.Splashes;
using Example.App.Commands;
using Example.Meta.Signals;
using UnityEngine.SceneManagement;
using Zenject;

namespace Example.Meta.Commands
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