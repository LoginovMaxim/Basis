using System.Collections.Generic;
using System.Linq;
using System.Text;
using Basis.App.Monos;
using Basis.App.UI.Screens.Logics;
using Basis.App.UI.Signals;
using Basis.Utils;
using UnityEngine;
using Zenject;

namespace Basis.App.UI.Services
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

            _currentScreen?.SetActive(false);
            _currentScreen = screen;
            _currentScreen.SetActive(true);
            
            if (_stackScreenIds.Count > 0 && _stackScreenIds.Peek() == _currentScreen.Id)
            {
                return;
            }

            if (HasBack(screenId, out var countPops))
            {
                for (var i = 0; i < countPops; i++)
                {
                    _stackScreenIds.Pop();
                }
            }
            else
            {
                _stackScreenIds.Push(_currentScreen.Id);
            }
            
            // Debug
            //PrintStackScreens();
        }

        private bool HasBack(int screenId, out int countPops)
        {
            countPops = 0;
            if (_stackScreenIds.Count < 2)
            {
                return false;
            }
            
            var stack = new Stack<int>(_stackScreenIds.Reverse());
            foreach (var id in stack)
            {
                if (id == screenId)
                {
                    return true;
                }
                
                countPops++;
            }
            
            return false;
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

        private void PrintStackScreens()
        {
            var stackInfo = new StringBuilder();
            stackInfo.Append("Screen stack: [");
            
            var screens = _stackScreenIds.ToList();
            for (var i = 0; i < screens.Count; i++)
            {
                stackInfo.Append($"{screens[i]}");
                if (i != screens.Count - 1)
                {
                    stackInfo.Append(", ");
                }
            }
            
            stackInfo.Append("]");
            Debug.Log(stackInfo.ToString().WithColor(Color.cyan));
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