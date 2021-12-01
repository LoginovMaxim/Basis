using System.Collections.Generic;
using Zenject;

namespace Assemblers
{
    public abstract class Assembler : IInitializable
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

        public async void Initialize()
        {
            while (_assemblerParts.Count > 0)
            {
                await _assemblerParts.Dequeue().Launch();
            }
        }
    }
}