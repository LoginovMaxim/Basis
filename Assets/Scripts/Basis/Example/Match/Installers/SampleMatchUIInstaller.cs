﻿using Basis.Example.Match.UI;
using Basis.Example.Match.UI.GameplayScreen;
using Basis.Example.Match.UI.PauseScreen;
using Zenject;

namespace Basis.Example.Match.Installers
{
    public sealed class SampleMatchUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SampleGameplayScreenViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SamplePauseScreenViewModel>().FromComponentInHierarchy().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<SampleGameplayScreen>().AsSingle().WithArguments((int) SampleMatchScreenId.Gameplay).NonLazy();
            Container.BindInterfacesTo<SamplePauseScreen>().AsSingle().WithArguments((int) SampleMatchScreenId.Pause).NonLazy();
            
            Container.BindInterfacesTo<SampleMatchScreenService>().AsSingle().NonLazy();
        }
    }
}