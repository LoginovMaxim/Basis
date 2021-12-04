using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace FSM
{
    public class TestMachine
    {
        private enum TestMachineState
        {
            Idle,
            Move,
            Jump
        }
        
        private readonly IStateMachine _stateMachine;

        public TestMachine(StateMachine.Factory stateMachineFactory)
        {
            _stateMachine = stateMachineFactory.Create(UpdateType.Update);

            var idleState = new State(Parser.GetEnumName(TestMachineState.Idle));
            idleState.SetEnter(() =>
            {
                Debug.Log($"Enter {idleState.StateCode}");
            });
            idleState.SetUpdate(() =>
            {
                Debug.Log($"Update {idleState.StateCode}");
            });
            idleState.SetExit(() =>
            {
                Debug.Log($"Exit {idleState.StateCode}");
            });
            idleState.SetTransitions(new List<ITransition>
            {
                new Transition(Parser.GetEnumName(TestMachineState.Move), () => Input.GetKeyDown(KeyCode.W)),
                new Transition(Parser.GetEnumName(TestMachineState.Jump), () => Input.GetKeyDown(KeyCode.Space))
            });
            
            var moveState = new State(Parser.GetEnumName(TestMachineState.Move));
            moveState.SetEnter(() =>
            {
                Debug.Log($"Enter {moveState.StateCode}");
            });
            moveState.SetUpdate(() =>
            {
                Debug.Log($"Update {moveState.StateCode}");
            });
            moveState.SetExit(() =>
            {
                Debug.Log($"Exit {moveState.StateCode}");
            });
            moveState.SetTransitions(new List<ITransition>
            {
                new Transition(Parser.GetEnumName(TestMachineState.Idle), () => Input.GetKeyDown(KeyCode.I)),
                new Transition(Parser.GetEnumName(TestMachineState.Jump), () => Input.GetKeyDown(KeyCode.Space))
            });
            
            var jumpState = new State(Parser.GetEnumName(TestMachineState.Jump));
            jumpState.SetEnter(() =>
            {
                Debug.Log($"Enter {jumpState.StateCode}");
            });
            jumpState.SetUpdate(() =>
            {
                Debug.Log($"Update {jumpState.StateCode}");
            });
            jumpState.SetExit(() =>
            {
                Debug.Log($"Exit {jumpState.StateCode}");
            });
            jumpState.SetTransitions(new List<ITransition>
            {
                new Transition(Parser.GetEnumName(TestMachineState.Idle), () => Input.GetKeyDown(KeyCode.I)),
                new Transition(Parser.GetEnumName(TestMachineState.Move), () => Input.GetKeyDown(KeyCode.W))
            });
            
            _stateMachine.AddState(idleState);
            _stateMachine.AddState(moveState);
            _stateMachine.AddState(jumpState);
            
            _stateMachine.SetInitialState(idleState.StateCode);
        }
    }
}