using System;
using Basis.App.SignalInfos;
using Basis.App.Signals;
using Zenject;

namespace Basis.App.Commands
{
    public abstract class Command<TSignalData, TSignal> : IDisposable 
        where TSignalData : ISignalData
        where TSignal : Signal<TSignalData>
    {
        protected readonly SignalBus _signalBus;

        protected Command(SignalBus signalBus)
        {
            _signalBus = signalBus;
            Subscribe();
        }

        protected abstract void Execute(TSignalData signalData);

        private void Subscribe()
        {
            _signalBus.Subscribe<TSignal>(signal => Execute(signal.SignalData));
        }

        private void Unsubscribe()
        {
            _signalBus.Unsubscribe<TSignal>(signal => Execute(signal.SignalData));
        }
        
        public void Dispose()
        {
            Unsubscribe();
        }
    }
}