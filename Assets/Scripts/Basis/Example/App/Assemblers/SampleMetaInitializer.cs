using System.Threading.Tasks;
using Basis.App.Assemblers;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleMetaInitializer : IAssemblerPart
    {
        public async Task Launch()
        {
            await Task.Delay(500);
        }
    }
}