using System.Threading.Tasks;

namespace Basis.App.Assemblers
{
    public interface IAssemblerPart
    {
        Task Launch();
    }
}