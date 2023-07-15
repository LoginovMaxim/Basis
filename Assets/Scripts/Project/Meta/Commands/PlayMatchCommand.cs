using Basis.Commands;
using Project.Meta.Signals;
using Zenject;

namespace Project.Meta.Commands
{
    public sealed class PlayMatchCommand : Command<PlayMatchSignal>
    {
        public PlayMatchCommand(SignalBus signalBus) : base(signalBus)
        {
        }

        protected override void Execute()
        {
            
        }
    }
}