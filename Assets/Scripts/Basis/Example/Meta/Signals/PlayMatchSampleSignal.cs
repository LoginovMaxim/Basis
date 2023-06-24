using Basis.App.Signals;

namespace Basis.Example.Meta.Signals
{
    public sealed class PlayMatchSampleSignal : Signal<EmptySignalData>
    {
        public PlayMatchSampleSignal(EmptySignalData signalData) : base(signalData)
        {
        }
    }
}