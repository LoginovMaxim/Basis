using Basis.App.Signals;

namespace Basis.Example.Meta.Signals
{
    public class PlayMatchSampleSignal : Signal<EmptySignalData>
    {
        public PlayMatchSampleSignal(EmptySignalData signalData) : base(signalData)
        {
        }
    }
}