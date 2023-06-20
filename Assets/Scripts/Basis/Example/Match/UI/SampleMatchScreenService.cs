using System.Collections.Generic;
using Basis.App.UI.Services;
using Zenject;

namespace Basis.Example.Match.UI
{
    public sealed class SampleMatchScreenService : ScreenService<ISampleMatchScreen>, ISampleMatchScreenService
    {
        public SampleMatchScreenService(List<ISampleMatchScreen> screens, SignalBus signalBus) : base(screens, signalBus)
        {
        }

        public void ChangeScreen(SampleMatchScreenId sampleMatchScreenId)
        {
            OnChangeScreenButtonClicked((int) sampleMatchScreenId);
        }
    }
}