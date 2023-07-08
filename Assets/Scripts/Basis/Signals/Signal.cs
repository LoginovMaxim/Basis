namespace Basis.Signals
{
    public abstract class Signal<TSignalData> where TSignalData : ISignalData
    {
        public TSignalData SignalData { get; }

        protected Signal(TSignalData signalData)
        {
            SignalData = signalData;
        }
    }
}