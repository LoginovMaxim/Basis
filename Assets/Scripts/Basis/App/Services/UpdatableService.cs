﻿using System;
using Basis.App.Monos;

namespace Basis.App.Services
{
    public abstract class UpdatableService : IUpdatableService, IDisposable
    {
        private readonly IMonoUpdater _monoUpdater;
        private bool _isPause = true;
        
        protected UpdatableService(IMonoUpdater monoUpdater, UpdateType updateType, bool isImmediateStart)
        {
            _monoUpdater = monoUpdater;

            switch (updateType)
            {
                case UpdateType.Update:
                    _monoUpdater.Subscribe(UpdateType.Update, OnUpdate);
                    break;
                case UpdateType.FixedUpdate:
                    _monoUpdater.Subscribe(UpdateType.FixedUpdate, OnUpdate);
                    break;
                case UpdateType.LateUpdate:
                    _monoUpdater.Subscribe(UpdateType.LateUpdate, OnUpdate);
                    break;
            }

            if (isImmediateStart)
            {
                Start();
            }
        }

        protected virtual void Start()
        {
            Unpause();    
        }

        protected abstract void Update();

        private void OnUpdate()
        {
            if (_isPause)
            {
                return;
            }

            Update();
        }
        
        protected void Pause()
        {
            _isPause = true;
        }

        protected void Unpause()
        {
            _isPause = false;
        }
        
        protected virtual void Dispose()
        {
            _monoUpdater.Unsubscribe(UpdateType.Update, OnUpdate);
            _monoUpdater.Unsubscribe(UpdateType.FixedUpdate, OnUpdate);
            _monoUpdater.Unsubscribe(UpdateType.LateUpdate, OnUpdate);
        }
        
        #region IUpdateService

        bool IUpdatableService.IsPaused => _isPause;
        
        void IUpdatableService.Pause()
        {
            Pause();
        }

        void IUpdatableService.Unpause()
        {
            Unpause();
        }

        #endregion

        #region IDisposable

        void IDisposable.Dispose()
        {
            Dispose();
        }

        #endregion
    }
}