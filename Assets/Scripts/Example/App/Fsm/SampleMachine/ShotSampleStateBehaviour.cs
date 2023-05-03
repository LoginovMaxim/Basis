using System.Collections.Generic;
using App.Fsm;
using UnityEngine;
using Utils;

namespace Example.App.Fsm.SampleMachine
{
    public class ShotSampleStateBehaviour : StateBehaviour
    {
        private float _relaxationTime = 3;
        private float _elapsedRelaxationTime;
        
        public ShotSampleStateBehaviour(IState state) : base(state)
        {
        }

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

        public override List<ITransition> GetTransitions()
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