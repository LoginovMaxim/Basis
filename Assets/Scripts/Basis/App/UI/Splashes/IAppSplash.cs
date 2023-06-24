using Basis.App.Assemblers;

namespace Basis.App.UI.Splashes
{
    public interface IAppSplash : ISplash
    {
        void AddAssembler(IAssembler assembler);
    }
}