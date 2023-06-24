using Basis.App.Signals;

namespace Basis.Example.Match.Signals
{
    public sealed class PauseMatchSampleSignal : Signal<EmptySignalData>
    {
        public PauseMatchSampleSignal(EmptySignalData signalData) : base(signalData)
        {
        }
    }
}