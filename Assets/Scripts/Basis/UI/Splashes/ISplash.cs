using System;
using Basis.Assemblers;
using Cysharp.Threading.Tasks;

namespace Basis.UI.Splashes
{
    public interface ISplash
    {
        event Action<float> OnLoadProgressChanged; 
        UniTask Show();
        UniTask Hide();
        void AddAssembler(IAssembler assembler);
    }
}