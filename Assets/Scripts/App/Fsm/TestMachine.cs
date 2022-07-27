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
        
        private readonly IStateMachine _stateMachine;

        public TestMachine(StateMachine.Factory stateMachineFactory)
        {
            _stateMachine = stateMachineFactory.Create();

            var idleState = new State(TestMachineState.Idle.ToString());
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
                new Transition(TestMachineState.Move.ToString(), () => Input.GetKeyDown(KeyCode.W)),
                new Transition(TestMachineState.Jump.ToString(), () => Input.GetKeyDown(KeyCode.Space))
            });
            
            var moveState = new State(TestMachineState.Move.ToString());
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
                new Transition(TestMachineState.Idle.ToString(), () => Input.GetKeyDown(KeyCode.I)),
                new Transition(TestMachineState.Jump.ToString(), () => Input.GetKeyDown(KeyCode.Space))
            });
            
            var jumpState = new State(TestMachineState.Jump.ToString());
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
                new Transition(TestMachineState.Idle.ToString(), () => Input.GetKeyDown(KeyCode.I)),
                new Transition(TestMachineState.Move.ToString(), () => Input.GetKeyDown(KeyCode.W))
            });
            
            _stateMachine.AddState(idleState);
            _stateMachine.AddState(moveState);
            _stateMachine.AddState(jumpState);
            
            _stateMachine.SetInitialState(idleState.StateCode);
        }
    }
}