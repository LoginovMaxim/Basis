using System.Threading.Tasks;

namespace Assemblers
{
    public abstract class AssemblerPart : IAssemblerPart
    {
        public Task Launch()
        {
            return LaunchProcess();
        }

        protected abstract Task LaunchProcess();
    }
}