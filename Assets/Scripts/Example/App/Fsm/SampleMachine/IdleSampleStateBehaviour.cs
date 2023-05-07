using System.Collections.Generic;
using App.Fsm;
using UnityEngine;

namespace Example.App.Fsm.SampleMachine
{
    public class IdleSampleStateBehaviour : IStateBehaviour
    {
        public void OnEnter()
        {
            Debug.Log($"Sit down");
        }

        public void OnUpdate()
        {
            Debug.Log($"Looking around");
        }

        public void OnExit()
        {
            Debug.Log($"Get up");
        }

        public List<ITransition> GetTransitions()
        {
            var shotTransition = new Transition(SampleMachineState.Shot, CanShot);
            return new List<ITransition> { shotTransition };
        }

        private bool CanShot()
        {
            return Random.Range(0, 100) == 0;
        }
    }
}