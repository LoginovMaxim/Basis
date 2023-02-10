using System;
using System.Collections.Generic;
using App.Fsm;
using App.Localizations;
using App.Monos;
using App.UI.Services;
using UnityEngine;
using Zenject;

namespace Example.App.UI.Screens
{
    public sealed class ExampleScreenService : ScreenService<IExampleScreen>, IExampleScreenService, IDisposable
    {
        private readonly ILocalization _localization;
        private readonly IMonoUpdater _monoUpdater;
        
        public ExampleScreenService(
            List<IExampleScreen> screens, 
            ILocalization localization,
            IMonoUpdater monoUpdater,
            SignalBus signalBus) : 
            base(screens, signalBus)
        {
            _localization = localization;
            _monoUpdater = monoUpdater;
            
            _monoUpdater.Subscribe(UpdateType.Update, OnUpdate);
        }

        public void ChangeScreen(ExampleScreenId exampleScreenId)
        {
            OnChangeScreenButtonClicked((int) exampleScreenId);
        }

        private void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _localization.SetLanguage(Language.EN);
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                _localization.SetLanguage(Language.RU);
            }
        }

        public void Dispose()
        {
            _monoUpdater.Unsubscribe(UpdateType.Update, OnUpdate);
        }
    }
}