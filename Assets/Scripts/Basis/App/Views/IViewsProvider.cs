﻿using System.Collections.Generic;

namespace Basis.App.Views
{
    public interface IViewsProvider
    {
        public IEnumerable<KeyValuePair<int, IViewObject>> ViewsByEntityIds { get; }
        public bool TryAdd(int entityId, IViewObject view);
        public bool TryRemove(int entityId);
        public bool TryGet(int entityId, out IViewObject view);
    }
}