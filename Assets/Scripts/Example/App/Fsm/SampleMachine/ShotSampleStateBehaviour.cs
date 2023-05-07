using System.Collections.Generic;
using App.Fsm;
using UnityEngine;
using Utils;

namespace Example.App.Fsm.SampleMachine
{
    public class ShotSampleStateBehaviour : IStateBehaviour
    {
        private float _relaxationTime = 3;
        private float _elapsedRelaxationTime;

        public void OnEnter()
        {
            Debug.Log($"Shot");
        }

        public void OnUpdate()
        {
            Debug.Log($"Wait");
        }

        public void OnExit()
        {
            Debug.Log($"Hide weapon");
        }

        public List<ITransition> GetTransitions()
        {
            var idleTransition = new Transition(SampleMachineState.Idle, IsRelaxationTimeOver);
            return new List<ITransition> { idleTransition };
        }

        private bool IsRelaxationTimeOver()
        {
            return _relaxationTime.IsTimeOver(ref _elapsedRelaxationTime);
        }
    }
}