using System;
using System.Collections.Generic;

namespace Editor.Configs
{
    public sealed class SheetRow : ISheetRow
    {
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

        private object GetValue(string name)
        {
            if (!_nameToIndexMap.TryGetValue(name, out var index))
            {
                throw new ArgumentException($"Unexpected value '{ name }' [{ _sheet.Name }]");
            }
            return index < _values.Count ? _values[index] : null;
        }

        private object GetValueByIndex(int i)
        {
            return _values[i];
        }

        private string GetValueAsString(string name)
        {
            return GetValue(name).ToString();
        }

        private bool GetValueAsBool(string name)
        {
            return Convert.ToBoolean(GetValue(name));
        }

        private int GetValueAsInt(string name)
        {
            return Convert.ToInt32(GetValue(name));
        }

        private float GetValueAsFloat(string name)
        {
            return Convert.ToSingle(GetValue(name));
        }

        #region ISheetRow

        int ISheetRow.Length => _values.Count;

        object ISheetRow.this[string name] => GetValue(name);

        object ISheetRow.GetValueByIndex(int i)
        {
            return GetValueByIndex(i);
        }

        object ISheetRow.GetValue(string name)
        {
            return GetValue(name);
        }

        string ISheetRow.GetValueAsString(string name)
        {
            return GetValueAsString(name);
        }

        bool ISheetRow.GetValueAsBool(string name)
        {
            return GetValueAsBool(name);
        }

        int ISheetRow.GetValueAsInt(string name)
        {
            return GetValueAsInt(name);
        }

        float ISheetRow.GetValueAsFloat(string name)
        {
            return GetValueAsFloat(name);
        }

        #endregion
    }
}