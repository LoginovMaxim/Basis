using Basis.App.Assemblers;
using Basis.App.UI.Splashes;

namespace Azur.TowerDefense.App.UI.Splashes
{
    public interface IAppSplash : ISplash
    {
        void AddAssembler(IAssembler assembler);
    }
}