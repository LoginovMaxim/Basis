using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assemblers
{
    public abstract class Assembler : MonoBehaviour
    {
        public Queue<IAssemblerPart> AssemblerParts { get; private set; }

        protected void InitializeAssemblerParts(params IAssemblerPart[] assemblerParts)
        {
            AssemblerParts = new Queue<IAssemblerPart>();
            foreach (var assemblerPart in assemblerParts)
            {
                AssemblerParts.Enqueue(assemblerPart);
            }
        }

        private void Start()
        {
            StartCoroutine(PrecessingAssemblers());
        }

        private IEnumerator PrecessingAssemblers()
        {
            while (AssemblerParts.Count > 0)
            {
                var currentAssemblerPart = AssemblerParts.Dequeue();
                currentAssemblerPart.Launch();
                
                while (currentAssemblerPart.AssemblerStep == AssemblerStep.Processing)
                {
                    yield return null;
                }
                
                yield return null;
            }
        }
    }
}