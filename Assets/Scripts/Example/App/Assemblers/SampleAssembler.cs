using App.Assemblers;
using Example.App.Services;
using Example.Ecs;
using Zenject;

namespace Example.App.Assemblers
{
    public sealed class SampleAssembler : Assembler
    {
        [Inject] public async void Inject(SampleService sampleService, SampleEcsService sampleEcsService)
        {
            await LaunchAssemblerPartsAsync(sampleService, sampleEcsService);
        }
    }
}