using System.Threading;
using Basis.Commands;
using Project.App.Services;
using Project.App.Signals;
using Zenject;

namespace Project.App.Commands
{
    public sealed class QuitMatchCommand : Command<QuitMatchSignal>
    {
        private readonly IMetaSceneLoader _metaSceneLoader;
        private readonly IMatchSceneLoader _matchSceneLoader;

        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        
        public QuitMatchCommand(
            IMetaSceneLoader metaSceneLoader, 
            IMatchSceneLoader matchSceneLoader, 
            SignalBus signalBus) : 
            base(signalBus)
        {
            _metaSceneLoader = metaSceneLoader;
            _matchSceneLoader = matchSceneLoader;
        }

        protected override async void Execute()
        {
            await _matchSceneLoader.UnloadAsync(_tokenSource.Token);
            await _metaSceneLoader.LoadAsync(_tokenSource.Token);
        }

        public override void Dispose()
        {
            base.Dispose();
            _tokenSource.Cancel();
        }
    }
}