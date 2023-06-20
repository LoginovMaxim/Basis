using System.Threading.Tasks;
using Basis.App.Assemblers;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleAuthorization : IAssemblerPart
    {
        public async Task Launch()
        {
            // authorization pipeline
            await Task.Delay(200);
        }
    }
}