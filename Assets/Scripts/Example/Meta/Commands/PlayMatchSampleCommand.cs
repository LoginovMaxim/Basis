using App.Monos;
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
        
        public PlayMatchSampleCommand(ISceneLoader sceneLoader, SignalBus signalBus) : base(signalBus)
        {
            _sceneLoader = sceneLoader;
        }

        private void OnPlayMatch()
        {
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