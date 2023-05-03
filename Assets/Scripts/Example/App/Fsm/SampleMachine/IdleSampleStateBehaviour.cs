using System.Collections.Generic;
using App.Fsm;
using UnityEngine;

namespace Example.App.Fsm.SampleMachine
{
    public class IdleSampleStateBehaviour : StateBehaviour
    {
        public IdleSampleStateBehaviour(IState state) : base(state)
        {
        }

        public override void OnEnter()
        {
            Debug.Log($"Sit down");
        }

        public override void OnUpdate()
        {
            Debug.Log($"Looking around");
        }

        public override void OnExit()
        {
            Debug.Log($"Get up");
        }

        public override List<ITransition> GetTransitions()
        {
            var shotTransition = new Transition(SampleMachineState.Shot, Shot);
            return new List<ITransition> { shotTransition };
        }

        private bool Shot()
        {
            return Random.Range(0, 100) == 0;
        }
    }
}