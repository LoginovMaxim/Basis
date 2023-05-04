using System.Threading.Tasks;
using App.Assemblers;

namespace Example.App.Assemblers
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