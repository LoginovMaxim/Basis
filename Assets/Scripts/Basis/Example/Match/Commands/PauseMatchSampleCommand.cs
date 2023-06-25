using System.Collections.Generic;
using Basis.App.Commands;
using Basis.App.Services;
using Basis.Example.Match.Signals;
using Zenject;

namespace Basis.Example.Match.Commands
{
    public class PauseMatchSampleCommand : Command<PauseMatchSampleSignal>
    {
        private readonly List<IUpdatableService> _updatableServices;
        
        public PauseMatchSampleCommand(List<IUpdatableService> updatableServices, SignalBus signalBus) : base(signalBus)
        {
            _updatableServices = updatableServices;
        }

        protected override void Execute()
        {
            _updatableServices.ForEach(service => service.Pause());
        }
    }
}