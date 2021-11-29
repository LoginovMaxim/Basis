namespace Assembler
{
    public abstract class BaseAssemblerPart : IAssemblerPart
    {
        public AssemblerStep AssemblerStep => _assemblerStep;

        private AssemblerStep _assemblerStep;
        
        public void Launch()
        {
            SetAssemblerStep(AssemblerStep.Processing);
            LaunchProcess();
            SetAssemblerStep(AssemblerStep.Assembled);
        }

        protected abstract void LaunchProcess();

        private void SetAssemblerStep(AssemblerStep assemblerStep) => _assemblerStep = assemblerStep;
    }
}