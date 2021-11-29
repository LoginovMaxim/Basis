using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembler
{
    public abstract class BaseAssembler : MonoBehaviour
    {
        protected Queue<IAssemblerPart> AssemblerParts;

        public BaseAssembler()
        {
            AssemblerParts = new Queue<IAssemblerPart>();
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