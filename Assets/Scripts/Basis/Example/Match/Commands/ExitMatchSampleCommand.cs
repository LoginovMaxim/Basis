using System.Threading;
using Basis.App.Commands;
using Basis.Example.App.Services;
using Basis.Example.Match.Signals;
using Zenject;

namespace Basis.Example.Match.Commands
{
    public sealed class ExitMatchSampleCommand : Command<ExitMatchSampleSignal>
    {
        private readonly ISampleMetaSceneLoader _sampleMetaSceneLoader;
        
        public ExitMatchSampleCommand(ISampleMetaSceneLoader sampleMetaSceneLoader, SignalBus signalBus) : base(signalBus)
        {
            _sampleMetaSceneLoader = sampleMetaSceneLoader;
        }

        protected override async void Execute()
        {
            await _sampleMetaSceneLoader.LoadAsync(new CancellationToken());
        }
    }
}