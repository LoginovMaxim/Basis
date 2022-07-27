using System.Collections.Generic;
using UnityEngine;

namespace App.Fsm
{
    public sealed class TestMachine
    {
        private enum TestMachineState
        {
            Idle,
            Move,
            Jump
        }
        
        private readonly Transition IdleTransition = new (TestMachineState.Idle, () => Input.GetKeyDown(KeyCode.I));
        private readonly Transition MoveTransition = new (TestMachineState.Move, () => Input.GetKeyDown(KeyCode.W));
        private readonly Transition JumpTransition = new (TestMachineState.Jump, () => Input.GetKeyDown(KeyCode.Space));
        
        private readonly IStateMachine _stateMachine;

        public TestMachine(StateMachine.Factory stateMachineFactory)
        {
            _stateMachine = stateMachineFactory.Create();

            var idleState = new State(TestMachineState.Move);
            idleState
                .SetEnter(() => Debug.Log($"Enter {idleState.StateCode}"))
                .SetUpdate(() => Debug.Log($"Update {idleState.StateCode}"))
                .SetExit(() => Debug.Log($"Exit {idleState.StateCode}"))
                .SetTransitions(new List<ITransition> { MoveTransition, JumpTransition });
            
            var moveState = new State(TestMachineState.Move);
            moveState
                .SetEnter(() => Debug.Log($"Enter {moveState.StateCode}"))
                .SetUpdate(() => Debug.Log($"Update {moveState.StateCode}"))
                .SetExit(() => Debug.Log($"Exit {moveState.StateCode}"))
                .SetTransitions(new List<ITransition> { IdleTransition, JumpTransition });
            
            var jumpState = new State(TestMachineState.Jump);
            jumpState
                .SetEnter(() => Debug.Log($"Enter {jumpState.StateCode}"))
                .SetUpdate(() => Debug.Log($"Update {jumpState.StateCode}"))
                .SetExit(() => Debug.Log($"Exit {jumpState.StateCode}"))
                .SetTransitions(new List<ITransition> { IdleTransition, MoveTransition });
            
            _stateMachine.AddState(idleState);
            _stateMachine.AddState(moveState);
            _stateMachine.AddState(jumpState);
            
            _stateMachine.SetInitialState(idleState.StateCode);
        }
    }
}