using System;
using Zenject;

namespace Basis.App.Commands
{
    public abstract class EmptyCommand : IDisposable
    {
        protected readonly SignalBus _signalBus;

        protected EmptyCommand(SignalBus signalBus)
        {
            _signalBus = signalBus;
            Subscribe();
        }

        protected abstract void Subscribe();
        protected abstract void Unsubscribe();
        
        public void Dispose()
        {
            Unsubscribe();
        }
    }
}