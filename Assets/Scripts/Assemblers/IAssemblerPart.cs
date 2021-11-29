namespace Assembler
{
    public interface IAssemblerPart
    {
        AssemblerStep AssemblerStep { get; }

        void Launch();
    }
}