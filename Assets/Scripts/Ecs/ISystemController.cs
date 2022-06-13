namespace Ecs
{
    public interface ISystemController
    {
        void SetSystemState(string systemName, bool state);
    }
}