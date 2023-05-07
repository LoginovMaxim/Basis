using System.Collections.Generic;
using App.Services;
using Example.App.Commands;
using Example.Match.Ecs;
using Example.Match.Signals;
using Zenject;

namespace Example.Match.Commands
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