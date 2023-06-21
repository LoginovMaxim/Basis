using Basis.App.Monos;
using Basis.App.Services;
using Basis.Example.Match.Fsm.SampleMachine;

namespace Basis.Example.Match.Services
{
    public sealed class SampleService : UpdatableService, ISampleService
    {
        private readonly ISampleStateMachine<SampleMachineState> _sampleStateMachine;

        public SampleService(
            ISampleStateMachine<SampleMachineState> sampleStateMachine, 
            IMonoUpdater monoUpdater, 
            UpdateType updateType, 
            bool isImmediateStart) : 
            base(monoUpdater, updateType, isImmediateStart)
        {
            _sampleStateMachine = sampleStateMachine;
            _sampleStateMachine.Start();
        }

        protected override void Update()
        {
            _sampleStateMachine.Update();
        }
    }
}