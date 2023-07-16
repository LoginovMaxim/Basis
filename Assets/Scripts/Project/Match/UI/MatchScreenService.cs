using System.Collections.Generic;
using Basis.UI.Screens;
using Zenject;

namespace Project.Match.UI
{
    public sealed class MatchScreenService : ScreenService<IMatchScreen>, IMatchScreenService
    {
        public MatchScreenService(List<IMatchScreen> screens, SignalBus signalBus) : base(screens, signalBus)
        {
        }
    }
}