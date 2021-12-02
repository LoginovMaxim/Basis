using System.Threading.Tasks;

namespace Assemblers
{
    public abstract class AssemblerPart : IAssemblerPart
    {
        public abstract Task Launch();
    }
}