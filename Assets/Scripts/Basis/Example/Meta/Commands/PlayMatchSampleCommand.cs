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
        private const string SampleMatchScenePath = "Example/Scenes/MatchExample";
        
        private readonly ISceneLoader _sceneLoader;
        private readonly IAppSplash _appSplash;
        
        public PlayMatchSampleCommand(ISceneLoader sceneLoader, IAppSplash appSplash, SignalBus signalBus) : base(signalBus)
        {
            _sceneLoader = sceneLoader;
            _appSplash = appSplash;
        }

        protected override void Execute()
        {
            _appSplash.Show();
            _sceneLoader.LoadScene(SampleMatchScenePath, LoadSceneMode.Single, null);
        }
    }
}