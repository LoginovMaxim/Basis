using System;
using Basis.Assemblers;

namespace Basis.UI.Splashes
{
    public interface ISplash
    {
        event Action<float> OnLoadProgressChanged; 
        void Show();
        void Hide();
        void AddAssembler(IAssembler assembler);
    }
}