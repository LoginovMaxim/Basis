using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Basis.Configs
{
    public abstract class AssetsCollection<TItem> : ScriptableObject where TItem : Object
    {
        [SerializeField] protected List<TItem> _items = new();
        public List<string> Ids = new();
        
#if UNITY_EDITOR
        [NonSerialized] private string[] _idsArray;
        [NonSerialized] private Dictionary<string, int> _idsToIndexes;
        
        public string[] IdsArray => _idsArray ??= Ids.ToArray();
        public Dictionary<string, int> IdsToIndexes => _idsToIndexes ??= Ids
                .Select((str, index) => new { Key = str, Value = index })
                .ToDictionary(item => item.Key, item => item.Value);
#endif

        protected TItem GetItem(string id)
        {
            var index = Ids.IndexOf(id);
            if (index == -1)
            {
                Debug.LogError($"can't find item by id {id}");
                return default;
            }

            return _items[index];
        }

        protected abstract void SetId(TItem item, string id);
        
#if UNITY_EDITOR

        public virtual void Fill(TItem[] units)
        {
            _items = new List<TItem>(units);
            CleanUpAndSetIds();
        }

        public void Refresh()
        {
            if (_items.Count != Ids.Count)
            {
                CleanUpAndSetIds();
            }
        }

        private void CleanUpAndSetIds()
        {
            Ids.Clear();
            var indexesToRemove = new List<int>();
            for (var i = 0; i < _items.Count; i++)
            {
                if (_items[i] == null)
                {
                    indexesToRemove.Add(i);
                    continue;
                }

                var id = Path.GetFileNameWithoutExtension(UnityEditor.AssetDatabase.GetAssetPath(_items[i]));

                if (Ids.Contains(id))
                {
                    indexesToRemove.Add(i);
                    continue;
                }

                SetId(_items[i], id);
                Ids.Add(id); 

            }

            _idsArray = null;
            _idsToIndexes = null;

            foreach (var index in indexesToRemove)
            {
                _items.RemoveAt(index);
            }
        }
#endif
    }
}