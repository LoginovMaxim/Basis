using Basis.App.Commands;
using Basis.App.Monos;
using Basis.App.UI.Splashes;
using Basis.Example.Meta.Signals;
using UnityEngine.SceneManagement;
using Zenject;

namespace Basis.Example.Meta.Commands
{
    public sealed class PlayMatchSampleCommand : Command<PlayMatchSampleSignal>
    {
        private const string SampleMatchScenePath = "Basis/Example/Scenes/MatchExample";
        
        private readonly ISceneLoader _sceneLoader;
        private readonly ISplash _splash;
        
        public PlayMatchSampleCommand(ISceneLoader sceneLoader, ISplash splash, SignalBus signalBus) : base(signalBus)
        {
            _sceneLoader = sceneLoader;
            _splash = splash;
        }

        protected override void Execute()
        {
            _splash.Show();
            _sceneLoader.LoadScene(SampleMatchScenePath, LoadSceneMode.Single, null);
        }
    }
}