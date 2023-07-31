using System;
using System.Collections.Generic;

namespace Basis.Editor.Configs
{
    public sealed class Sheet : ISheet
    {
        public string Name => _name;

        public string[] Header => _header;

        public ISheetRow this[string columnName, string value] => GetRow(columnName, value);
        
        private readonly string _name;
        private readonly string[] _header;
        private readonly Dictionary<string, int> _nameToIndexMap = new Dictionary<string, int>();
        private readonly List<ISheetRow> _rows = new List<ISheetRow>();

        public Sheet(string name, IList<IList<object>> values)
        {
            _name = name;
            var columns = values[0];
            _header = new string[columns.Count];
            for (var i = 0; i < columns.Count; ++i)
            {
                var columnName = _header[i] = (string)columns[i];
                _nameToIndexMap.Add(columnName, i);
            }
            for (var i = 1; i < values.Count; ++i)
            {
                _rows.Add(new SheetRow(this, _nameToIndexMap, values[i]));
            }
        }

        public List<ISheetRow> GetRows()
        {
            return _rows;
        }

        public List<ISheetRow> SelectRows(Func<ISheetRow, bool> match)
        {
            var rows = new List<ISheetRow>();
            foreach (var row in _rows)
            {
                if (match(row))
                {
                    rows.Add(row);
                }
            }
            return rows;
        }

        public ISheetRow GetRow(string columnName, string value)
        {
            var rows = SelectRows(row => (string)row[columnName] == value);
            if (rows.Count < 1)
            {
                throw new ArgumentException($"Row [{ columnName },{ value }] not found");
            }
            if (rows.Count > 1)
            {
                throw new ArgumentException($"Too many rows [{ columnName },{ value }]");
            }
            return rows[0];
        }
    }
}