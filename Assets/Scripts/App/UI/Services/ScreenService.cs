using System;
using System.Collections.Generic;
using System.Linq;
using App.Fsm;
using App.Monos;
using App.UI.Screens.Logics;
using App.UI.Signals;
using UnityEngine;
using Zenject;

namespace App.UI.Services
{
    public abstract class ScreenService<TScreen> : IScreenService where TScreen : IScreen
    {
        private readonly List<TScreen> _screens;
        private readonly IMonoUpdater _monoUpdater;
        private readonly SignalBus _signalBus;

        private TScreen _currentScreen;
        private Stack<int> _stackScreenIds = new Stack<int>();

        protected ScreenService(List<TScreen> screens, SignalBus signalBus)
        {
            _screens = screens;
            _screens.ForEach(screen =>
            {
                screen.SetActive(false);
            });

            _signalBus = signalBus;
            _signalBus.Subscribe<SwitchScreenSignal>(x => OnChangeScreenButtonClicked(x.ScreenId));

            _currentScreen = _screens[0];
            _currentScreen.SetActive(true);
            _stackScreenIds.Push(_currentScreen.Id);
        }

        protected void OnChangeScreenButtonClicked(int screenId)
        {
            if (screenId == -1)
            {
                OnBackScreenButtonClicked();
                return;
            }
            
            var screen = _screens.FirstOrDefault(screen => screen.Id == screenId);
            if (screen == null)
            {
                return;
            }

            _currentScreen.SetActive(false);
            _currentScreen = screen;
            _currentScreen.SetActive(true);
            
            if (_stackScreenIds.Count > 0 && _stackScreenIds.Peek() == _currentScreen.Id)
            {
                return;
            }
            
            _stackScreenIds.Push(_currentScreen.Id);
        }

        private void OnBackScreenButtonClicked()
        {
            if (_stackScreenIds.Count < 2)
            {
                return;
            }

            _stackScreenIds.Pop();
            var lastScreenId = _stackScreenIds.Pop();
            OnChangeScreenButtonClicked(lastScreenId);
        }

        #region IMetaScreenService

        public IScreen CurrentScreen => _currentScreen;
        
        void IScreenService.OnChangeScreenButtonClicked(int screenId)
        {
            OnChangeScreenButtonClicked(screenId);
        }

        #endregion
    }
}