using System.Collections.Generic;
using Basis.App.UI.Services;
using Zenject;

namespace Basis.Example.Meta.UI
{
    public class SampleMetaScreenService : ScreenService<ISampleMetaScreen>, ISampleMetaScreenService
    {
        public SampleMetaScreenService(List<ISampleMetaScreen> screens, SignalBus signalBus) : base(screens, signalBus)
        {
        }

        public void ChangeScreen(SampleMetaScreenId sampleMetaScreenId)
        {
            OnChangeScreenButtonClicked((int) sampleMetaScreenId);
        }
    }
}