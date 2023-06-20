using System.Threading.Tasks;
using Basis.App.Assemblers;
using Basis.App.Fsm;
using Basis.App.Monos;
using Basis.App.Services;

namespace Basis.Example.App.Services
{
    public sealed class SampleService : UpdatableService, ISampleService, IAssemblerPart
    {
        public SampleService(IMonoUpdater monoUpdater, UpdateType updateType, bool isImmediateStart) : 
            base(monoUpdater, updateType, isImmediateStart)
        {
        }

        public async Task Launch()
        {
            await Task.Delay(500);
            Start();
        }
        
        protected override void Update()
        {
            // обновляемая логика сервиса
        }
    }
}