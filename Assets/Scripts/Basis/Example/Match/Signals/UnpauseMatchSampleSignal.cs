using Basis.App.Signals;

namespace Basis.Example.Match.Signals
{
    public class UnpauseMatchSampleSignal : Signal<EmptySignalData>
    {
        public UnpauseMatchSampleSignal(EmptySignalData signalData) : base(signalData)
        {
        }
    }
}