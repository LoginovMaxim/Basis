﻿using Basis.App.Assemblers;

namespace Basis.App.UI.Splashes
{
    public interface ISplash
    {
        void Show();
        void Hide();
        void AddAssembler(IAssembler assembler);
    }
}