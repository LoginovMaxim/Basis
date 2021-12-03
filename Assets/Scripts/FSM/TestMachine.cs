using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace FSM
{
    public class TestMachine
    {
        public enum TestMachineState
        {
            Idle,
            Move,
            Jump
        }
        
        private readonly IStateMachine _stateMachine;

        public TestMachine(StateMachine.Factory stateMachineFactory)
        {
            _stateMachine = stateMachineFactory.Create(UpdateType.Update);

            var idleTransitions = new List<ITransition>
            {
                new Transition(Parser.GetEnumName(TestMachineState.Move), () => Input.GetKeyDown(KeyCode.W)),
                new Transition(Parser.GetEnumName(TestMachineState.Jump), () => Input.GetKeyDown(KeyCode.Space))
            };
            var idleState = new State(Parser.GetEnumName(TestMachineState.Idle), idleTransitions);
            idleState
                .SetEnterAction(() =>
                {
                    Debug.Log($"Enter {idleState.StateCode}");
                })
                .SetUpdateAction(() =>
                {
                    Debug.Log($"Update {idleState.StateCode}");
                })
                .SetExitAction(() =>
                {
                    Debug.Log($"Exit {idleState.StateCode}");
                });
            
            var moveTransitions = new List<ITransition>
            {
                new Transition(Parser.GetEnumName(TestMachineState.Idle), () => Input.GetKeyDown(KeyCode.I)),
                new Transition(Parser.GetEnumName(TestMachineState.Jump), () => Input.GetKeyDown(KeyCode.Space))
            };
            var moveState = new State(Parser.GetEnumName(TestMachineState.Move), moveTransitions);
            moveState
                .SetEnterAction(() =>
                {
                    Debug.Log($"Enter {moveState.StateCode}");
                })
                .SetUpdateAction(() =>
                {
                    Debug.Log($"Update {moveState.StateCode}");
                })
                .SetExitAction(() =>
                {
                    Debug.Log($"Exit {moveState.StateCode}");
                });
            
            var jumpTransitions = new List<ITransition>
            {
                new Transition(Parser.GetEnumName(TestMachineState.Idle), () => Input.GetKeyDown(KeyCode.I)),
                new Transition(Parser.GetEnumName(TestMachineState.Move), () => Input.GetKeyDown(KeyCode.W))
            };
            var jumpState = new State(Parser.GetEnumName(TestMachineState.Jump), jumpTransitions);
            jumpState
                .SetEnterAction(() =>
                {
                    Debug.Log($"Enter {jumpState.StateCode}");
                })
                .SetUpdateAction(() =>
                {
                    Debug.Log($"Update {jumpState.StateCode}");
                })
                .SetExitAction(() =>
                {
                    Debug.Log($"Exit {jumpState.StateCode}");
                });
            
            _stateMachine.AddState(idleState);
            _stateMachine.AddState(moveState);
            _stateMachine.AddState(jumpState);
            
            _stateMachine.SetInitialState(idleState.StateCode);
        }
    }
}