using System.Collections.Generic;
using Basis.Utils;
using UnityEngine;

namespace Basis.Views
{
    public sealed class ViewsProvider : IViewsProvider
    {
        public IEnumerable<KeyValuePair<int, IViewObject>> ViewsByEntityIds => _viewsByEntityIds;
        private Dictionary<int, IViewObject> _viewsByEntityIds;

        public ViewsProvider()
        {
            _viewsByEntityIds = new Dictionary<int, IViewObject>(256);
        }

        public bool TryAdd(int entityId, IViewObject view)
        {
            if (_viewsByEntityIds.ContainsKey(entityId))
            {
                Debug.Log($"Entity {entityId} already has a view {view.GetType()}".WithColor(Colors.Orange));
                return false;
            }
            
            _viewsByEntityIds.Add(entityId, view);
            return true;
        }

        public bool TryRemove(int entityId)
        {
            if (!_viewsByEntityIds.ContainsKey(entityId))
            {
                Debug.Log($"Missing ViewObject for entityId: {entityId}".WithColor(Colors.Orange));
                return false;
            }
            
            _viewsByEntityIds.Remove(entityId);
            return true;
        }

        public bool TryGet(int entityId, out IViewObject view)
        {
            if (!_viewsByEntityIds.TryGetValue(entityId, out view))
            {
                Debug.Log($"Missing ViewObject for entityId: {entityId}".WithColor(Colors.Orange));
                return false;
            }
            
            return true;
        }
    }
}