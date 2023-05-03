using App.Fsm;

namespace Example.App.Fsm.SampleMachine
{
    public sealed class SampleStateMachine
    {
        private readonly IStateMachine _stateMachine;

        public SampleStateMachine(StateMachine.Factory stateMachineFactory)
        {
            _stateMachine = stateMachineFactory.Create();

            var idleState = new State(SampleMachineState.Idle);
            var idleStateBehaviour = new IdleSampleStateBehaviour(idleState);
            
            var shotState = new State(SampleMachineState.Shot);
            var shotStateBehaviour = new ShotSampleStateBehaviour(shotState);
            
            _stateMachine.AddState(idleState);
            _stateMachine.AddState(shotState);
            
            _stateMachine.SetInitialState(idleState.StateCode);
        }
    }
}