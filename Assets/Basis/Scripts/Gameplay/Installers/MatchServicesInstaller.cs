﻿using Zenject;

namespace Basis.Gameplay.Installers
{
    public sealed class MatchServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindScreens();
            BindScreenService();
        }

        private void BindScreens()
        {
        }

        private void BindScreenService()
        {
        }
    }
}