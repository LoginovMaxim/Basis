using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Assemblers
{
    public abstract class Assembler
    {
        private Queue<IAssemblerPart> _assemblerParts;

        protected async Task InitializeAssemblerParts(params IAssemblerPart[] assemblerParts)
        {
            _assemblerParts = new Queue<IAssemblerPart>();
            foreach (var assemblerPart in assemblerParts)
            {
                _assemblerParts.Enqueue(assemblerPart);
            }

            await LaunchAsync();
        }

        private async Task LaunchAsync()
        {
            while (_assemblerParts.Count > 0)
            {
                await _assemblerParts.Dequeue().Launch();
            }
        }
    }
}