using System;
using Basis.Signals;
using Zenject;

namespace Basis.Commands
{
    public abstract class Command<TSignal> : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        
        protected Command(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        protected abstract void Execute();

        public void Initialize()
        {
            _signalBus.Subscribe<TSignal>(Execute);
        }

        public virtual void Dispose()
        {
            _signalBus.Unsubscribe<TSignal>(Execute);
        }
    }
    
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

        public virtual void Dispose()
        {
            _signalBus.Unsubscribe<TSignal>(Execute);
        }

        private void Execute(TSignal signal)
        {
            Execute(signal.SignalData);
        }
    }
}