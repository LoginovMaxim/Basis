using System.Collections.Generic;
using Basis.UI.Screens;
using Zenject;

namespace Project.Meta.UI
{
    public sealed class MetaScreenService : ScreenService<IMetaScreen>, IMetaScreenService
    {
        public MetaScreenService(List<IMetaScreen> screens, SignalBus signalBus) : base(screens, signalBus)
        {
        }
    }
}