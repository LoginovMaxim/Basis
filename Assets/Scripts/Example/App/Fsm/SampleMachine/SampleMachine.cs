using App.Fsm;

namespace Example.App.Fsm.SampleMachine
{
    public sealed class SampleStateMachine
    {
        private readonly IStateMachine _stateMachine;

        public SampleStateMachine(StateMachine.Factory stateMachineFactory)
        {
            _stateMachine = stateMachineFactory.Create();

            var idleStateBehaviour = new IdleSampleStateBehaviour();
            var idleState = State.NewInstance(SampleMachineState.Idle, idleStateBehaviour);
            
            var shotStateBehaviour = new ShotSampleStateBehaviour();
            var shotState = State.NewInstance(SampleMachineState.Shot, shotStateBehaviour);
            
            _stateMachine.AddState(idleState);
            _stateMachine.AddState(shotState);
            
            _stateMachine.SetInitialState(idleState.StateCode);
            _stateMachine.Start();
        }
    }
}