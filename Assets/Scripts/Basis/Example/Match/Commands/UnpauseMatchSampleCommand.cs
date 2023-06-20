using System.Collections.Generic;
using Basis.App.Services;
using Basis.Example.App.Commands;
using Basis.Example.Match.Signals;
using Zenject;

namespace Basis.Example.Match.Commands
{
    public class UnpauseMatchSampleCommand : Command
    {
        private readonly List<IUpdatableService> _updatableServices;
        
        public UnpauseMatchSampleCommand(List<IUpdatableService> updatableServices, SignalBus signalBus) : base(signalBus)
        {
            _updatableServices = updatableServices;
        }

        private void OnUnpauseMatch()
        {
            _updatableServices.ForEach(service => service.Unpause());
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