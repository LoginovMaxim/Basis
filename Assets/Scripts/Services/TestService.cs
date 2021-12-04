using System.Threading.Tasks;
using Monos;
using UnityEngine;

namespace Services
{
    public class TestService : Service
    {
        public TestService(MonoUpdater monoUpdater) : base(monoUpdater)
        {
        }

        public override async Task Launch()
        {
            await Task.Delay(1);
            Start();
        }

        protected override void ProcessRun()
        {
            Debug.Log("TestService.ProcessRun");
        }
    }
}