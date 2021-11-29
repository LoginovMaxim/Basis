namespace Assemblers
{
    public interface IAssemblerPart
    {
        AssemblerStep AssemblerStep { get; }

        void Launch();
    }
}