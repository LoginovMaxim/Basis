using System;
using Basis.App.Signals;
using Zenject;

namespace Basis.App.Commands
{
    public abstract class Command<TSignalData, TSignal> : IInitializable, IDisposable
        where TSignalData : ISignalData 
        where TSignal : Signal<TSignalData>
    {
        private readonly SignalBus _signalBus;
        
        protected Command(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        protected abstract void Execute(TSignalData signalData);

        public void Initialize()
        {
            _signalBus.Subscribe<TSignal>(Execute);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<TSignal>(Execute);
        }

        private void Execute(TSignal signal)
        {
            Execute(signal.SignalData);
        }
    }
}