using System.Collections.Generic;
using App.UI.Services;
using Zenject;

namespace Example.Match.UI
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