using System.Collections.Generic;
using Basis.App.Services;
using Basis.Example.App.Commands;
using Basis.Example.Match.Signals;
using Zenject;

namespace Basis.Example.Match.Commands
{
    public class PauseMatchSampleCommand : Command
    {
        private readonly List<IUpdatableService> _updatableServices;
        
        public PauseMatchSampleCommand(List<IUpdatableService> updatableServices, SignalBus signalBus) : base(signalBus)
        {
            _updatableServices = updatableServices;
        }

        private void OnPauseMatch()
        {
            _updatableServices.ForEach(service => service.Pause());
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