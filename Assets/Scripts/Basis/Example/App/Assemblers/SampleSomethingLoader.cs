using System.Threading;
using Basis.App.Assemblers;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleSomethingLoader : IAssemblerPart
    {
        public async UniTask Launch(CancellationToken token)
        {
            await UniTask.Delay(Random.Range(1000, 2000));
        }
    }
}