﻿using BasisCore.Runtime.UI.Window;

namespace Meta.UI.Main
{
    public class MetaMainWindowBinder : WindowBinder<MetaMainWindowModel, MetaMainWindowView>
    {
        public MetaMainWindowBinder(MetaMainWindowModel model, MetaMainWindowView view) : base(model, view)
        {
        }
    }
}