using Basis.App.Signals;

namespace Basis.Example.Match.Signals
{
    public sealed class UnpauseMatchSampleSignal : Signal<EmptySignalData>
    {
        public UnpauseMatchSampleSignal(EmptySignalData signalData) : base(signalData)
        {
        }
    }
}