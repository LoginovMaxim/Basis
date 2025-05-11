using System.Threading;
using BasisCore.Launchers;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Basis.Core.Launchers
{
    public sealed class CorrectLauncher : ILauncher
    {
        public async UniTask LaunchAsync(CancellationToken token)
        {
            Debug.Log("Running CorrectLauncher");
            await UniTask.Delay(200, cancellationToken: token);
        }
    }
}