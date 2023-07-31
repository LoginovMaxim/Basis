using System.Collections.Generic;

namespace Basis.Views
{
    public interface IViewsProvider
    {
        public IEnumerable<KeyValuePair<int, IViewObject>> ViewsByEntityIds { get; }
        public bool TryAdd(int entityId, IViewObject view);
        public bool TryRemove(int entityId);
        public bool TryGet<TViewObject>(int entityId, out TViewObject view) where TViewObject : IViewObject;
    }
}