﻿using Project.Match.Commands;
using Zenject;

namespace Project.Match.Installers
{
    public sealed class MatchCommandsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<QuitMatchCommand>().AsSingle().NonLazy();
        }
    }
}