using System;
using System.Collections.Generic;

namespace Basis.Editor.Configs
{
    public sealed class SheetRow : ISheetRow
    {
        public int Length => _values.Count;

        public object this[string name] => GetValue(name);
        
        private readonly ISheet _sheet;
        private readonly Dictionary<string, int> _nameToIndexMap;
        private readonly IList<object> _values;

        public SheetRow(
            ISheet sheet,
            Dictionary<string, int> nameToIndexMap,
            IList<object> values)
        {
            _sheet = sheet;
            _nameToIndexMap = nameToIndexMap;
            _values = values;
        }

        public object GetValue(string name)
        {
            if (!_nameToIndexMap.TryGetValue(name, out var index))
            {
                throw new ArgumentException($"Unexpected value '{ name }' [{ _sheet.Name }]");
            }
            return index < _values.Count ? _values[index] : null;
        }

        public object GetValueByIndex(int i)
        {
            return _values[i];
        }

        public string GetValueAsString(string name)
        {
            return GetValue(name).ToString();
        }

        public bool GetValueAsBool(string name)
        {
            return Convert.ToBoolean(GetValue(name));
        }

        public int GetValueAsInt(string name)
        {
            return Convert.ToInt32(GetValue(name));
        }

        public float GetValueAsFloat(string name)
        {
            return Convert.ToSingle(GetValue(name));
        }
    }
}