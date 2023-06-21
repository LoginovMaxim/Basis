using Basis.App.Signals;

namespace Basis.Example.Match.Signals
{
    public class PauseMatchSampleSignal : Signal<EmptySignalData>
    {
        public PauseMatchSampleSignal(EmptySignalData signalData) : base(signalData)
        {
        }
    }
}