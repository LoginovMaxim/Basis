using System.Threading.Tasks;
using App.Assemblers;
using App.Fsm;
using App.Monos;
using App.Services;
using UnityEngine;

namespace Example.App.Services
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
            Debug.Log("SampleService.Update");
        }
    }
}