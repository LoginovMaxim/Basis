using System;
using Zenject;

namespace Example.App.Commands
{
    public abstract class Command : IDisposable
    {
        protected readonly SignalBus _signalBus;

        protected Command(SignalBus signalBus)
        {
            _signalBus = signalBus;
            Subscribe();
        }

        protected abstract void Subscribe();
        protected abstract void Unsubscribe();

        #region IDisposable
        
        void IDisposable.Dispose()
        {
            Unsubscribe();
        }

        #endregion
    }
}