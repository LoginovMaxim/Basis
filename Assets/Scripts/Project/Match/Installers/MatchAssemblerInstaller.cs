﻿using System.Collections.Generic;
using Basis.Assemblers.Launchers;
using Basis.Utils;
using Project.Match.Assemblers;
using Zenject;

namespace Project.Match.Installers
{
    public sealed class MatchAssemblerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var assemblerLaunchers = new List<IAssemblerLauncher>();
            
            Container.BindAssembler<MatchAssembler>(assemblerLaunchers);
        }
    }
}