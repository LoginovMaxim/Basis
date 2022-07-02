using System;
using App.Fsm;

namespace App.Monos
{
    public interface IMonoUpdater
    {
        void Subscribe(UpdateType updateType, Action action);
        void Unsubscribe(UpdateType updateType, Action action);
    }
}