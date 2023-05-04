using Example.App.Commands;
using Example.Match.Ecs;
using Example.Match.Signals;
using Zenject;

namespace Example.Match.Commands
{
    public class PauseMatchSampleCommand : Command
    {
        private readonly ISampleEcsService _sampleEcsService;
        
        public PauseMatchSampleCommand(ISampleEcsService sampleEcsService, SignalBus signalBus) : base(signalBus)
        {
            _sampleEcsService = sampleEcsService;
        }

        private void OnPauseMatch()
        {
            _sampleEcsService.Pause();
        }
        
        protected override void Subscribe()
        {
            _signalBus.Subscribe<PauseMatchSampleSignal>(OnPauseMatch);
        }

        protected override void Unsubscribe()
        {
            _signalBus.Unsubscribe<PauseMatchSampleSignal>(OnPauseMatch);
        }
    }
}