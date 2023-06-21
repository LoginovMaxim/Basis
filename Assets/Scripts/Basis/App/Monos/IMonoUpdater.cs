using System;
using Basis.App.Services;

namespace Basis.App.Monos
{
    public interface IMonoUpdater
    {
        void Subscribe(UpdateType updateType, Action action);
        void Unsubscribe(UpdateType updateType, Action action);
    }
}