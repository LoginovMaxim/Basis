using Basis.Assemblers;

namespace Basis.UI.Splashes
{
    public interface ISplash
    {
        void Show();
        void Hide();
        void AddAssembler(IAssembler assembler);
    }
}