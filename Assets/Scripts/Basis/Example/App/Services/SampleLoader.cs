using System.Threading.Tasks;
using Basis.App.Assemblers;

namespace Basis.Example.App.Services
{
    public sealed class SampleLoader : ISampleLoader, IAssemblerPart
    {
        public async Task Launch()
        {
            await Task.Delay(100);
        }
    }
}