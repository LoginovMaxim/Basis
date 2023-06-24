using System.Collections.Generic;
using Basis.App.Commands;
using Basis.App.Services;
using Basis.App.Signals;
using Basis.Example.Match.Signals;
using Zenject;

namespace Basis.Example.Match.Commands
{
    public class UnpauseMatchSampleCommand : Command<EmptySignalData, UnpauseMatchSampleSignal>
    {
        private readonly List<IUpdatableService> _updatableServices;
        
        public UnpauseMatchSampleCommand(List<IUpdatableService> updatableServices, SignalBus signalBus) : base(signalBus)
        {
            _updatableServices = updatableServices;
        }

        protected override void Execute(EmptySignalData signalData)
        {
            _updatableServices.ForEach(service => service.Unpause());
        }
    }
}