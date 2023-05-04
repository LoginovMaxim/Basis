using System.Threading.Tasks;
using App.Assemblers;
using UnityEngine;

namespace Example.App.Assemblers
{
    public sealed class SampleSomethingLoader : IAssemblerPart
    {
        public async Task Launch()
        {
            await Task.Delay(Random.Range(2000, 4000));
        }
    }
}