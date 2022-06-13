using App.Assemblers;
using App.Services;
using Example.App.Services;
using Example.Ecs;
using Zenject;

namespace Example.App.Assemblers
{
    public sealed class SampleAssembler : Assembler
    {
        [Inject] public async void Inject(SampleService sampleService, SampleEcsWorldService sampleEcsWorldService)
        {
            await InitializeAssemblerParts(sampleService, sampleEcsWorldService);

            if (sampleService is IUpdatableService updatableService)
            {
                updatableService.Pause();
            }
        }
    }
}