using Editor.Configs;

namespace Editor.Utils
{
    public static class SheetExtension
    {
        public static int GetInt(this ISheet sheet, string name)
        {
            return sheet[ColumnNames.Id, name].GetValueAsInt(ColumnNames.Value);
        }
        
        public static float GetFloat(this ISheet sheet, string name)
        {
            return sheet[ColumnNames.Id, name].GetValueAsFloat(ColumnNames.Value);
        }
        
        public static string GetString(this ISheet sheet, string name)
        {
            return sheet[ColumnNames.Id, name].GetValueAsString(ColumnNames.Value);
        }
        
        public static bool GetBool(this ISheet sheet, string name)
        {
            return sheet[ColumnNames.Id, name].GetValueAsBool(ColumnNames.Value);
        }
    }
}