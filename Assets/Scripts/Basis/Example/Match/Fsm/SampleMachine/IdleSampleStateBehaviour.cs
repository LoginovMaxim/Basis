using System.Collections.Generic;
using Basis.App.Fsm;
using UnityEngine;

namespace Basis.Example.Match.Fsm.SampleMachine
{
    public class IdleSampleStateBehaviour : StateBehaviour<SampleMachineState>
    {
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

        public override List<ITransition<SampleMachineState>> GetTransitions()
        {
            var shotTransition = new Transition<SampleMachineState>(SampleMachineState.Shot, CanShot);
            return new List<ITransition<SampleMachineState>> { shotTransition };
        }

        private bool CanShot()
        {
            return Random.Range(0, 100) == 0;
        }
    }
}