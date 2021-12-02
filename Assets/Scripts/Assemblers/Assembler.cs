using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assemblers
{
    public abstract class Assembler : MonoBehaviour
    {
        private Queue<IAssemblerPart> _assemblerParts;

        protected void InitializeAssemblerParts(params IAssemblerPart[] assemblerParts)
        {
            _assemblerParts = new Queue<IAssemblerPart>();
            foreach (var assemblerPart in assemblerParts)
            {
                _assemblerParts.Enqueue(assemblerPart);
            }
        }

        public async void Start()
        {
            await Launch();
        }

        private async Task Launch()
        {
            while (_assemblerParts.Count > 0)
            {
                var currentAssemblerPart = _assemblerParts.Dequeue();
                await currentAssemblerPart.Launch();
            }
        }
    }
}