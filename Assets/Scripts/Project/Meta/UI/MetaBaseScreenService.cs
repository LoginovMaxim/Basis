using System.Collections.Generic;
using BasisCore.Runtime.UI.Screens;
using Zenject;

namespace Project.Meta.UI
{
    public sealed class MetaBaseScreenService : BaseScreenService<IMetaScreenController>, IMetaScreenService
    {
        public MetaBaseScreenService(List<IMetaScreenController> screens, SignalBus signalBus) : base(screens, signalBus)
        {
        }
    }
}