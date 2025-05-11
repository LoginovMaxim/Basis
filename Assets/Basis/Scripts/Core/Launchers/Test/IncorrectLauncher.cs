using System;
using System.Threading;
using BasisCore.Launchers;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Basis.Core.Launchers
{
    public sealed class IncorrectLauncher : ILauncher
    {
        private readonly LauncherType _launcherType;
        private int _iterations = 3;
        
        public IncorrectLauncher(LauncherType launcherType)
        {
            _launcherType = launcherType;
        }

        public async UniTask LaunchAsync(CancellationToken token)
        {
            Debug.Log($"Testing IncorrectLauncher ({_launcherType})");
            await UniTask.Delay(100, cancellationToken: token);
            
            _iterations--;
            if (_launcherType != LauncherType.Required && _iterations == 0)
            {
                return;
            }

            throw new Exception();
        }
    }
}