﻿using Zenject;

namespace Basis.Gameplay.Installers
{
    public sealed class MatchUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindWindowModels();
            BindWindowControllers();
        }

        private void BindWindowModels()
        {
        }

        private void BindWindowControllers()
        {
        }
    }
}