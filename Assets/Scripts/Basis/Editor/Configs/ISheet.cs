using System;
using System.Collections.Generic;

namespace Basis.Editor.Configs
{
    public interface ISheet
    {
        string Name { get; }
        string[] Header { get; }
        ISheetRow this[string columnName, string value] { get; }
        List<ISheetRow> GetRows();
        List<ISheetRow> SelectRows(Func<ISheetRow, bool> match);
        ISheetRow GetRow(string columnName, string value);
    }
}