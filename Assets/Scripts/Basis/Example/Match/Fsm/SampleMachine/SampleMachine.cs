using Basis.App.Fsm;

namespace Basis.Example.Match.Fsm.SampleMachine
{
    public sealed class SampleStateMachine : StateMachine<SampleMachineState>, ISampleStateMachine<SampleMachineState>
    {
        public SampleStateMachine()
        {
            AddState(SampleMachineState.Idle, new IdleSampleStateBehaviour());
            AddState(SampleMachineState.Shot, new ShotSampleStateBehaviour());
            SetInitialState(SampleMachineState.Idle);
        }
    }
}