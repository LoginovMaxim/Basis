using System.Threading;
using Basis.App.Assemblers;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Basis.Example.App.Assemblers
{
    public sealed class SampleSomethingLoader : IAssemblerPart
    {
        public UniTask Launch(CancellationToken token)
        {
            return UniTask.CompletedTask;
        }
    }
}