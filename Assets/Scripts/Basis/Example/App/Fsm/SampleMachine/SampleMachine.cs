using Basis.App.Fsm;
using Basis.App.Monos;

namespace Basis.Example.App.Fsm.SampleMachine
{
    public sealed class SampleStateMachine : StateMachine, ISampleStateMachine
    {
        public SampleStateMachine(IMonoUpdater monoUpdater) : base(monoUpdater)
        {
            var idleStateBehaviour = new IdleSampleStateBehaviour();
            var idleState = State.NewInstance(SampleMachineState.Idle, idleStateBehaviour);
            
            var shotStateBehaviour = new ShotSampleStateBehaviour();
            var shotState = State.NewInstance(SampleMachineState.Shot, shotStateBehaviour);
            
            AddState(idleState);
            AddState(shotState);
            
            SetInitialState(idleState.StateCode);
            Start();
        }
    }
}