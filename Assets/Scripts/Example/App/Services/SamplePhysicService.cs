using System.Threading.Tasks;
using App.Assemblers;
using App.Fsm;
using App.Monos;
using App.Services;
using UnityEngine;

namespace Example.App.Services
{
    public sealed class SamplePhysicService : UpdatableService, ISampleService, IAssemblerPart
    {
        public SamplePhysicService(IMonoUpdater monoUpdater, UpdateType updateType, bool isImmediateStart) : 
            base(monoUpdater, updateType, isImmediateStart)
        {
        }

        public async Task Launch()
        {
            await Task.Delay(10);
            Start();
        }
        
        protected override void Update()
        {
            Debug.Log("SamplePhysicService.Update");
        }
    }
}