using System;
using UnityEngine;

namespace Basis.Example.App.Data
{
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