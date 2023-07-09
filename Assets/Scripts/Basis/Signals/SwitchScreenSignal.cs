namespace Basis.Signals
{
    public class SwitchScreenSignal
    {
        public readonly int ScreenId;

        public SwitchScreenSignal(int screenId)
        {
            ScreenId = screenId;
        }
    }
}