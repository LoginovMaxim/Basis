using System;
using System.Collections.Generic;
using System.Linq;
using Basis.App.Data;
using UnityEngine;

namespace Basis.Example.App.Data
{
    [Serializable] public sealed class SampleListStorageItem : StorageItem
    {
        [SerializeField] private List<SampleDataItem> _sampleDataItems = new List<SampleDataItem>();
        
        public IEnumerable<SampleDataItem> GetTowerPlacements()
        {
            return _sampleDataItems;
        }
        
        public bool TryAddSampleDataItem(SampleDataItem sampleDataItem)
        {
            if (Contains(sampleDataItem.Id))
            {
                Debug.LogError($"Can't remove tower placement with {sampleDataItem.Id} id");
                return false;
            }
            
            _sampleDataItems.Add(sampleDataItem);
            SaveUpdatedItem();
            return true;
        }

        public bool TryRemoveSampleDataItem(int id)
        {
            var towerPlacement = _sampleDataItems.FirstOrDefault(t => t.Id == id);
            if (towerPlacement == null)
            {
                Debug.LogError($"Can't remove tower placement with {id} id");
                return false;
            }
            
            _sampleDataItems.Remove(towerPlacement);
            SaveUpdatedItem();
            return true;
        }
        
        public bool Contains(int id)
        {
            return _sampleDataItems.Any(t => t.Id == id);
        }
    }

    [Serializable] public sealed class SampleDataItem
    {
        [SerializeField] public int Id;
        [SerializeField] public string Label;

        public SampleDataItem(int id, string label)
        {
            Id = id;
            Label = label;
        }
    }
}