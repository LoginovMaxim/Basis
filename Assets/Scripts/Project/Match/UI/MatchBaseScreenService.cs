using System.Collections.Generic;
using BasisCore.Runtime.UI.Screens;
using Zenject;

namespace Project.Match.UI
{
    public sealed class MatchBaseScreenService : BaseScreenService<IMatchScreenController>, IMatchScreenService
    {
        public MatchBaseScreenService(List<IMatchScreenController> screens, SignalBus signalBus) : base(screens, signalBus)
        {
        }
    }
}