using System.Threading.Tasks;
using App.Assemblers;

namespace Example.App.Services
{
    public sealed class SampleLoader : ISampleLoader, IAssemblerPart
    {
        public async Task Launch()
        {
            await Task.Delay(100);
        }
    }
}