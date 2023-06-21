using System.Collections.Generic;
using Basis.App.Fsm;
using Basis.Utils;
using UnityEngine;

namespace Basis.Example.Match.Fsm.SampleMachine
{
    public class ShotSampleStateBehaviour : StateBehaviour<SampleMachineState>
    {
        private float _relaxationTime = 3;
        private float _elapsedRelaxationTime;

        public override void OnEnter()
        {
            Debug.Log($"Shot");
        }

        public override void OnUpdate()
        {
            Debug.Log($"Wait");
        }

        public override void OnExit()
        {
            Debug.Log($"Hide weapon");
        }

        public override List<ITransition<SampleMachineState>> GetTransitions()
        {
            var idleTransition = new Transition<SampleMachineState>(SampleMachineState.Idle, IsRelaxationTimeOver);
            return new List<ITransition<SampleMachineState>> { idleTransition };
        }

        private bool IsRelaxationTimeOver()
        {
            return _relaxationTime.IsTimeOver(ref _elapsedRelaxationTime);
        }
    }
}