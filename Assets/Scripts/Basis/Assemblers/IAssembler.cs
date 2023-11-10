namespace Basis.Assemblers
{
    public interface IAssembler
    {
        int ServicesCount { get; }
        int CurrentStepCount { get; }
        bool Launched { get; }
    }
}