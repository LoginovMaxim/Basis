﻿namespace Basis.App.UI.Signals
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