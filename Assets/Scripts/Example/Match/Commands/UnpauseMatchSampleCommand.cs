using Example.App.Commands;
using Example.Match.Ecs;
using Example.Match.Signals;
using Zenject;

namespace Example.Match.Commands
{
    public class UnpauseMatchSampleCommand : Command
    {
        private readonly ISampleEcsService _sampleEcsService;
        
        public UnpauseMatchSampleCommand(ISampleEcsService sampleEcsService, SignalBus signalBus) : base(signalBus)
        {
            _sampleEcsService = sampleEcsService;
        }

        private void OnUnpauseMatch()
        {
            _sampleEcsService.UnPause();
        }
        
        protected override void Subscribe()
        {
            _signalBus.Subscribe<UnpauseMatchSampleSignal>(OnUnpauseMatch);
        }

        protected override void Unsubscribe()
        {
            _signalBus.Unsubscribe<UnpauseMatchSampleSignal>(OnUnpauseMatch);
        }
    }
}