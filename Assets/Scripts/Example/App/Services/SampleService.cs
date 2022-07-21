using System;
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
        public SampleService(IMonoUpdater monoUpdater) : 
            base(monoUpdater, UpdateType.Update | UpdateType.LateUpdate)
        {
        }

        public async Task Launch()
        {
            await Task.Delay(1000);
            Start();
        }
        
        protected override void Update()
        {
            Debug.Log("SampleService.Update");
        }
        
        protected override void FixedUpdate()
        {
            Debug.Log("SampleService.FixedUpdate");
        }
        
        protected override void LateUpdate()
        {
            Debug.Log("SampleService.LateUpdate");
        }
    }
}