using System;
using Basis.Services;

namespace Basis.Monos
{
    public interface IMonoUpdater
    {
        void Subscribe(UpdateType updateType, Action action);
        void Unsubscribe(UpdateType updateType, Action action);
    }
}